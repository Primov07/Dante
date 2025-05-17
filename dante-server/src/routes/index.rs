use std::{ env, fs::File, io::Read, path::Path };

use choki::src::{ request::Request, response::Response, structs::{ ContentType, HttpServerError } };
use mongodb::sync::Database;

pub fn get(
    req: Request,
    mut res: Response,
    database: Option<Database>
) -> Result<(), HttpServerError> {
    let mut file = File::open("./ui/index.html").unwrap();

    let mut data = String::new();
    file.read_to_string(&mut data).unwrap();

    res.use_compression = true;

    res.send_bytes_chunked(data.as_bytes(), Some(ContentType::Html))
}
