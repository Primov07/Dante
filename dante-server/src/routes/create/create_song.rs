use std::{ env, fs::{ self, File }, io::Read, path::Path };

use choki::src::{ request::Request, response::Response, structs::{ ContentType, HttpServerError } };
use mongodb::sync::Database;

use crate::{ database_managers::{ song_manager, Controller }, schemas::song::Song };

pub fn post(
    req: Request,
    mut res: Response,
    database: Option<Database>
) -> Result<(), HttpServerError> {
    let body = req.body();
    let database = database.unwrap();
    let song_manager = song_manager::SongManager::new(&database);

    let title = String::from_utf8_lossy(body[0].data).to_string();
    let genre = String::from_utf8_lossy(body[1].data).to_string();

    let song = Song::new(title, genre);

    fs::write(format!("./songs/{}.mp3", song.id), body[2].data).unwrap();
    
    fs::write(format!("./images/song/{}.png", song.id), body[3].data).unwrap();

    let output = format!("Uploaded with id: {}", song.id);

    song_manager.create(song).unwrap();

    res.send_string(&output)
}
