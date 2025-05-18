use mongodb::{ bson::{ self, doc }, results::InsertOneResult, sync::{ Collection, Database } };

use crate::schemas::song::Song;

use super::Controller;

pub struct SongManager {
    collection: Collection<Song>,
}
impl SongManager {
    pub fn new(database: &Database) -> SongManager {
        SongManager { collection: database.collection("Songs") }
    }
}
impl Controller<Song> for SongManager {
    fn create(&self, input: Song) -> Result<InsertOneResult, mongodb::error::Error> {
        let res = self.collection.insert_one(input);
        res.run()
    }

    fn find(&self, id: i64) -> Option<Song> {
        let res = self.collection.find_one(doc! { "id": id });
        res.run().unwrap()
    }

    fn get_all(&self) -> Vec<Song> {
        let cursor = self.collection
            .find(doc! {})
            .run()
            .unwrap();

        cursor.map(|result| result.unwrap()).collect()
    }

    fn update(&self, input: Song) {
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
mod song_manager_tests {
    use std::env;
    use dotenv::dotenv;
    use mongodb::{ bson::doc, sync::{ Client, Collection } };

    use crate::{
        database_managers::{ song_manager::SongManager, Controller },
        schemas::song::Song,
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

        let song_manager = SongManager::new(&db);

        let song = Song::new("Test1".to_string(), "Rock".to_string());

        song_manager.create(song).unwrap();

        // Real Data
        let collection: Collection<Song> = db.collection("Songs");

        let document = collection
            .find_one(doc! { "title": "Test1" })
            .run()
            .unwrap();

        assert!(document.is_some());

        collection
            .delete_many(doc! {})
            .run()
            .unwrap();

        db.drop().run().unwrap();
    }

    #[test]
    fn find() {
        let uri = get_connection_string();

        let client = Client::with_uri_str(uri).unwrap();
        let db = client.database(&format!("Tests-{}", generate_id()));

        let song = Song::new("Test1".to_string(), "Rock".to_string());
        let id = song.id.clone();

        // Real Data
        let collection: Collection<Song> = db.collection("Songs");

        collection.insert_one(song).run().unwrap();
        //
        let song_manager = SongManager::new(&db);

        let found = song_manager.find(id);

        assert!(found.is_some());

        collection
            .delete_many(doc! {})
            .run()
            .unwrap();

        db.drop().run().unwrap();
    }
    #[test]
    fn get_all() {
        let uri = get_connection_string();

        let client = Client::with_uri_str(uri).unwrap();
        let db = client.database(&format!("Tests-{}", generate_id()));

        let song = Song::new("Test1".to_string(), "Rock".to_string());

        // Real Data
        let collection: Collection<Song> = db.collection("Songs");

        collection.insert_one(song).run().unwrap();
        //
        let song_manager = SongManager::new(&db);

        let found = song_manager.get_all();
        println!("{:?}", found);
        assert!(found.len() == 1);

        collection
            .delete_many(doc! {})
            .run()
            .unwrap();

        db.drop().run().unwrap();
    }
    #[test]
    fn update() {
        let uri = get_connection_string();

        let client = Client::with_uri_str(uri).unwrap();
        let db = client.database(&format!("Tests-{}", generate_id()));

        let mut song = Song::new("Test1".to_string(), "Rock".to_string());
        let id = song.id.clone();

        // Real Data
        let collection: Collection<Song> = db.collection("Songs");

        collection.insert_one(&song).run().unwrap();
        //

        let song_manager = SongManager::new(&db);
        song.title = "No".to_string();

        song_manager.update(song);

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

        db.drop().run().unwrap();
    }
    #[test]
    fn delete() {
        let uri = get_connection_string();

        let client = Client::with_uri_str(uri).unwrap();
        let db = client.database(&format!("Tests-{}", generate_id()));

        let song = Song::new("Test1".to_string(), "Rock".to_string());
        let id = song.id.clone();

        // Real Data
        let collection: Collection<Song> = db.collection("Songs");

        collection.insert_one(&song).run().unwrap();
        //

        let song_manager = SongManager::new(&db);

        song_manager.delete(id);

        let found = collection
            .find_one(doc! { "id":id })
            .run()
            .unwrap();

        assert!(found.is_none());

        collection
            .delete_many(doc! {})
            .run()
            .unwrap();

        db.drop().run().unwrap();
    }
}
