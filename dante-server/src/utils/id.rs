use rand::Rng;

pub fn generate_id() -> i64 {
    let mut rng = rand::rng();
    let random: i64 = rng.random();
    if random < 0 {
        return random * -1;
    }
    random
}
