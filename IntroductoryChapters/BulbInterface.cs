public interface BulbInterface
{
	void turnOn();
	void turnOff();
	bool IsOn { get; }
}

//implements BulbInterface
public class Bulb : BulbInterface
{
	//Instance Variables 
	private bool isOn = false;

	//Instance Method
	public virtual void turnOn()
	{
		isOn = true;
	}

	//Instance Method
	public virtual void turnOff()
	{
		isOn = false;
	}

	//Instance Method
	public virtual bool IsOn
	{
		get
		{
			return isOn;
		}
	}
}





public class AdvanceBulb : Bulb
{
	//Instance Variables
	private int intensity;

	//Instance Method
	public virtual int Intersity
	{
		get
		{
			return Intersity;
		}
		set
		{
			intensity = value;
		}
	}
}