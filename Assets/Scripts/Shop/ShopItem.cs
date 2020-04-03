

public class ShopItem {
    private string speed;
    private string rotate;
    private string model;
    private string price;
    private string id;

    public ShopItem(string id, string speed, string rotate, string model, string price)
    {
        this.Id = id;
        this.Speed = speed;
        this.Rotate = rotate;
        this.Model = model;
        this.Price = price;
    }

    public string Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public string Rotate
    {
        get
        {
            return rotate;
        }

        set
        {
            rotate = value;
        }
    }

    public string Model
    {
        get
        {
            return model;
        }

        set
        {
            model = value;
        }
    }

    public string Price
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
        }
    }

    public string Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public override string ToString()
    {
        return string.Format("{0}--{1}--{2}--{3}", speed, rotate, model, price);
    }
}
