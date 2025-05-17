use mongodb::{ bson::{ self, doc }, results::InsertOneResult, sync::{ Collection, Database } };

use crate::schemas::album::Album;

use super::Controller;

pub struct AlbumManager {
    collection: Collection<Album>,
}
impl AlbumManager {
    pub fn new(database: &Database) -> AlbumManager {
        AlbumManager { collection: database.collection("Albums") }
    }
}

impl Controller<Album> for AlbumManager {
    fn create(&self, input: Album) -> Result<InsertOneResult, mongodb::error::Error> {
        let res = self.collection.insert_one(input);
        res.run()
    }

    fn find(&self, id: i64) -> Option<Album> {
        let res = self.collection.find_one(doc! { "id": id });
        res.run().unwrap()
    }

    fn get_all(&self) -> Vec<Album> {
        let cursor = self.collection
            .find(doc! {})
            .run()
            .unwrap();

        cursor.map(|result| result.unwrap()).collect()
    }

    fn update(&self, input: Album) {
        self.collection
            .find_one_and_update(
                doc! { "id": &input.id },
                doc! { "$set": bson::to_bson(&input).unwrap() }
            )
            .run()
            .unwrap();
    }

    fn delete(&self, id: i64) {
        self.collection
            .delete_one(doc! { "id": id })
            .run()
            .unwrap();
    }
}

#[cfg(test)]
mod album_manager_tests {
    use std::env;
    use dotenv::dotenv;
    use mongodb::{ bson::doc, sync::{ Client, Collection } };

    use crate::{
        database_managers::{ album_manager::AlbumManager, Controller },
        schemas::album::Album,
        utils::id::generate_id,
    };

    fn get_connection_string() -> String {
        dotenv().ok();
        return env::var("MONGO_URI").unwrap();
    }

    #[test]
    fn create() {
        let uri = get_connection_string();

        let client = Client::with_uri_str(uri).unwrap();
        let db = client.database(&format!("Tests-{}", generate_id()));

        let album_manager = AlbumManager::new(&db);

        let album = Album::new("Test1".to_string());

        album_manager.create(album).unwrap();

        // Real Data
        let collection: Collection<Album> = db.collection("Albums");

        let document = collection
            .find_one(doc! { "title": "Test1" })
            .run()
            .unwrap();

        assert!(document.is_some());

        collection
            .delete_many(doc! {})
            .run()
            .unwrap();
    }

    #[test]
    fn find() {
        let uri = get_connection_string();

        let client = Client::with_uri_str(uri).unwrap();
        let db = client.database(&format!("Tests-{}", generate_id()));

        let album = Album::new("Test1".to_string());
        let id = album.id.clone();

        // Real Data
        let collection: Collection<Album> = db.collection("Albums");

        collection.insert_one(album).run().unwrap();
        //
        let album_manager = AlbumManager::new(&db);

        let found = album_manager.find(id);

        assert!(found.is_some());

        collection
            .delete_many(doc! {})
            .run()
            .unwrap();
    }
    #[test]
    fn get_all() {
        let uri = get_connection_string();

        let client = Client::with_uri_str(uri).unwrap();
        let db = client.database(&format!("Tests-{}", generate_id()));

        let album = Album::new("Test1".to_string());

        // Real Data
        let collection: Collection<Album> = db.collection("Albums");

        collection.insert_one(album).run().unwrap();
        //
        let album_manager = AlbumManager::new(&db);

        let found = album_manager.get_all();
        println!("{:?}", found);
        assert!(found.len() == 1);

        collection
            .delete_many(doc! {})
            .run()
            .unwrap();
    }
    #[test]
    fn update() {
        let uri = get_connection_string();

        let client = Client::with_uri_str(uri).unwrap();
        let db = client.database(&format!("Tests-{}", generate_id()));

        let mut album = Album::new("Test1".to_string());
        let id = album.id.clone();

        // Real Data
        let collection: Collection<Album> = db.collection("Albums");

        collection.insert_one(&album).run().unwrap();
        //

        let album_manager = AlbumManager::new(&db);
        album.title = "No".to_string();

        album_manager.update(album);

        let found = collection
            .find_one(doc! { "id":id })
            .run()
            .unwrap();

        assert!(found.is_some());
        assert!(found.unwrap().title == "No");

        collection
            .delete_many(doc! {})
            .run()
            .unwrap();
    }
    #[test]
    fn delete() {
        let uri = get_connection_string();

        let client = Client::with_uri_str(uri).unwrap();
        let db = client.database(&format!("Tests-{}", generate_id()));

        let album = Album::new("Test1".to_string());
        let id = album.id.clone();

        // Real Data
        let collection: Collection<Album> = db.collection("Albums");

        collection.insert_one(&album).run().unwrap();
        //

        let album_manager = AlbumManager::new(&db);

        album_manager.delete(id);

        let found = collection
            .find_one(doc! { "id":id })
            .run()
            .unwrap();

        assert!(found.is_none());

        collection
            .delete_many(doc! {})
            .run()
            .unwrap();
    }
}
