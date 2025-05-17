use serde::{ Deserialize, Serialize };

use crate::utils::id::generate_id;

#[derive(Serialize, Deserialize, Debug, Clone)]
pub struct Album {
    pub id: i64,
    pub title: String,
    pub songs: Vec<i64>,
}
impl Album {
    pub fn new(title: String) -> Album {
        Album {
            id: generate_id(),
            title: title,
            songs: Vec::new(),
        }
    }
}
