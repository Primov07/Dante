use serde::{ Deserialize, Serialize };

use crate::utils::id::generate_id;

#[derive(Serialize, Deserialize, Debug, Clone)]
pub struct Artist {
    pub id: i64,
    pub name: String,
    pub rating: f32,

    pub albums: Vec<i64>,
    pub songs: Vec<i64>,
}
impl Artist {
    pub fn new(name: String, rating: f32) -> Artist {
        Artist {
            id: generate_id(),
            name: name,
            rating: rating,
            albums: Vec::new(),
            songs: Vec::new(),
        }
    }
}
