using entity_framework_store_example;
using entity_framework_store_example.Data;

using var context = new StoreDbContext();
		
context.Database.EnsureCreated();

StoreDbCrudManager.Run(context);