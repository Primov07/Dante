use serde::{ Deserialize, Serialize };

use crate::utils::id::generate_id;

#[derive(Serialize, Deserialize, Debug, Clone)]
pub struct Song {
    pub id: i64,
    pub title: String,
    pub genre: String,
}
impl Song {
    pub fn new(title: String, genre: String) -> Song {
        Song {
            id: generate_id(),
            title: title,
            genre: genre,
        }
    }
}
