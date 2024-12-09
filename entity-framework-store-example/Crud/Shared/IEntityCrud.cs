namespace entity_framework_store_example.Crud.Shared;

public interface IEntityCrud
{
	void SelectAction();
	void DisplayAll();
	void DisplayById();
	void DeleteById();
	void Create();
	void Update();
}