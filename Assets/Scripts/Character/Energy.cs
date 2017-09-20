public class Energy{

	public float totalEnergy;
	public float actualEnergy;

	public Energy(){
	}

	public bool canUse (Skill skill){
		if (actualEnergy >= skill.cost) {
			actualEnergy = actualEnergy - skill.cost;
			return true;
		}
		return false;
	}	
}

