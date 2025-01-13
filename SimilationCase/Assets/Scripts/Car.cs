[System.Serializable]
public class Car
{
    public string modelName;
    public float topSpeed; 
    public int price;
    public int carIndex;
    public float condition;
    public Car(string modelName, float topSpeed, int price, int carIndex)
    {
        this.modelName = modelName;
        this.topSpeed = topSpeed;
        this.price = price;
        this.carIndex = carIndex;
        condition = 100;
    }
}