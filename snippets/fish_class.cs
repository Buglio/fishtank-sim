public class Fish
{
    public int Id;
    public int Age = f0;
    public int Gender = 0; // 0=male,1=female
    public int Hunger = f50; //0=starving,100=full
    public int Health = f100; //0=dying,100=healthy

    public Fish(int id)
    {
        Id = id;
        string fish = JsonUtility.ToJson(fish.json);
        fishObject = JsonUtility.FromJson<MyClass>(fish);
        data = fishObject[id];

        // do things with data
        public void UpdateFish() {
            Age = Age + f0.001;
            Hunger = Hunger - f0.01;
            Health = Health + variables; // lots of variables for health
        }
        public void AffectEnvironment() {
            // get data from fish json

            // apply changes to environment (ammonia goes up, etc)
        }
    }
}