use std::{ env, fs::{ self, File }, io::Read, path::Path };

use choki::src::{ request::Request, response::Response, structs::{ ContentType, HttpServerError } };
use mongodb::sync::Database;

use crate::{ database_managers::{ artist_manager, Controller }, schemas::artist::Artist };

pub fn get(
    req: Request,
    mut res: Response,
    database: Option<Database>
) -> Result<(), HttpServerError> {
    let database = database.unwrap();
    let artist_manager = artist_manager::ArtistManager::new(&database);

    let all = artist_manager.get_all();

    let output = serde_json::to_string_pretty(&all).unwrap_or_default();

    res.send_json(&output)
}
