use mongodb::results::InsertOneResult;

pub mod song_manager;
pub mod album_manager;
pub mod artist_manager;

pub trait Controller<T> {
    fn create(&self, input: T) -> Result<InsertOneResult, mongodb::error::Error>;

    fn find(&self, id: i64) -> Option<T>;

    fn get_all(&self) -> Vec<T>;

    fn update(&self, input: T);

    fn delete(&self, id: i64);
}
