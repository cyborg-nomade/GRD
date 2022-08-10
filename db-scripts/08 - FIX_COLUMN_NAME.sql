ALTER TABLE "GRD"."GRD_PROPOSICOES" RENAME COLUMN "ProtoloExpediente" TO "ProtocoloExpediente"
/

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (N'20220810115543_FixColumnName', N'6.0.7')
/

