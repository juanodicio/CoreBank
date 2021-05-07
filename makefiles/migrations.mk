
migrations.list:
	dotnet ef migrations list \
		--project app/src/Infrastructure \
		--startup-project app/src/WebApi
		
migrations.add:
	dotnet ef migrations add $(name) \
		--project app/src/Infrastructure \
		--startup-project app/src/WebApi \
		--output-dir Persistence/Migrations
		
migrations.remove:
	dotnet ef migrations remove \
		--startup-project app/src/WebApi \
		--project app/src/Infrastructure
		
migrations.script:
	dotnet ef migrations script $(name) --idempotent \
		--startup-project app/src/WebApi

db.update:
	dotnet ef database update $(migration) \
		--project app/src/Infrastructure \
		--startup-project app/src/WebApi
