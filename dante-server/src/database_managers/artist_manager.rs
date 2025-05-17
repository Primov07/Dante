use mongodb::{ bson::{ self, doc }, results::InsertOneResult, sync::{ Collection, Database } };

use crate::schemas::artist::Artist;

use super::Controller;

pub struct ArtistManager {
    collection: Collection<Artist>,
}
impl ArtistManager {
    pub fn new(database: &Database) -> ArtistManager {
        ArtistManager { collection: database.collection("Artists") }
    }
}

impl Controller<Artist> for ArtistManager {
    fn create(&self, input: Artist) -> Result<InsertOneResult, mongodb::error::Error> {
        let res = self.collection.insert_one(input);
        res.run()
    }

    fn find(&self, id: i64) -> Option<Artist> {
        let res = self.collection.find_one(doc! { "id": id });
        res.run().unwrap()
    }

    fn get_all(&self) -> Vec<Artist> {
        let cursor = self.collection
            .find(doc! {})
            .run()
            .unwrap();

        cursor.map(|result| result.unwrap()).collect()
    }

    fn update(&self, input: Artist) {
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
mod artist_manager_tests {
    use std::env;
    use dotenv::dotenv;
    use mongodb::{ bson::doc, sync::{ Client, Collection } };

    use crate::{
        database_managers::{ artist_manager::ArtistManager, Controller },
        schemas::artist::Artist,
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

        let artist_manager = ArtistManager::new(&db);

        let artist = Artist::new("Test1".to_string(), 5.0);

        artist_manager.create(artist).unwrap();

        // Real Data
        let collection: Collection<Artist> = db.collection("Artists");

        let document = collection
            .find_one(doc! { "name": "Test1" })
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

        let artist = Artist::new("Test1".to_string(), 5.0);
        let id = artist.id.clone();

        // Real Data
        let collection: Collection<Artist> = db.collection("Artists");

        collection.insert_one(&artist).run().unwrap();
        //
        let artist_manager = ArtistManager::new(&db);

        let found = artist_manager.find(id);

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

        let artist = Artist::new("Test1".to_string(), 5.0);

        // Real Data
        let collection: Collection<Artist> = db.collection("Artists");

        collection.insert_one(&artist).run().unwrap();
        //
        let artist_manager = ArtistManager::new(&db);

        let found = artist_manager.get_all();

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

        let mut artist = Artist::new("Test1".to_string(), 5.0);
        let id = artist.id.clone();

        // Real Data
        let collection: Collection<Artist> = db.collection("Artists");

        collection.insert_one(&artist).run().unwrap();
        //

        let artist_manager = ArtistManager::new(&db);
        artist.name = "No".to_string();

        artist_manager.update(artist);

        let found = collection
            .find_one(doc! { "id":id })
            .run()
            .unwrap();

        assert!(found.is_some());
        assert!(found.unwrap().name == "No");

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

        let artist = Artist::new("Test1".to_string(),5.0);
        let id = artist.id.clone();

        // Real Data
        let collection: Collection<Artist> = db.collection("Artists");

        collection.insert_one(&artist).run().unwrap();
        //

        let artist_manager = ArtistManager::new(&db);

        artist_manager.delete(id);

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
