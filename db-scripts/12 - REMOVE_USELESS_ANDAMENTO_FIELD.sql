ALTER TABLE "GRD"."GRD_ANDAMENTOS" DROP COLUMN "NomeResponsavel"
/

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (N'20220815150808_RemoveUselessAndamentoField', N'6.0.8')
/

