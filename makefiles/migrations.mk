
migrations.add:
	dotnet ef migrations add $(name) \
		--project app/src/Infrastructure \
		--startup-project app/src/WebApi \
		--output-dir Persistence/Migrations
		
migrations.remove:
	dotnet ef migrations remove \
		--startup-project app/src/WebApi \ 
		--project app/src/Infrastructure

db.update:
	dotnet ef database update \
		--project app/src/Infrastructure \
		--startup-project app/src/WebApi
