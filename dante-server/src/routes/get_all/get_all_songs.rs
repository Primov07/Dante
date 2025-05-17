use std::{ env, fs::{ self, File }, io::Read, path::Path };

use choki::src::{ request::Request, response::Response, structs::{ ContentType, HttpServerError } };
use mongodb::sync::Database;

use crate::{ database_managers::{ song_manager, Controller }, schemas::song::{ self, Song } };

pub fn get(
    req: Request,
    mut res: Response,
    database: Option<Database>
) -> Result<(), HttpServerError> {
    let database = database.unwrap();
    let song_manager = song_manager::SongManager::new(&database);

    let all = song_manager.get_all();

    let output = serde_json::to_string_pretty(&all).unwrap_or_default();

    res.send_string(&output)
}
