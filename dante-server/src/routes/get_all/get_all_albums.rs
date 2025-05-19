use std::{ env, fs::{ self, File }, io::Read, path::Path };

use choki::src::{ request::Request, response::Response, structs::{ ContentType, HttpServerError } };
use mongodb::sync::Database;

use crate::{ database_managers::{ album_manager, Controller }, schemas::album::Album };

pub fn get(
    req: Request,
    mut res: Response,
    database: Option<Database>
) -> Result<(), HttpServerError> {
    let database = database.unwrap();
    let album_manager = album_manager::AlbumManager::new(&database);

    let all = album_manager.get_all();

    let output = serde_json::to_string_pretty(&all).unwrap_or_default();

    res.send_json(&output)
}
