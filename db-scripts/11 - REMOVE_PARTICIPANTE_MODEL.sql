﻿ALTER TABLE "GRD"."GRD_PART_REUNIAO" DROP CONSTRAINT "FK_PartReuniao_PartId"
/

ALTER TABLE "GRD"."GRD_PARTPREV_REUNIAO" DROP CONSTRAINT "FK_PartPrevReuniao_PartId"
/

ALTER TABLE "GRD"."GRD_VOTOS" DROP CONSTRAINT "FK_Votos_Part"
/

DROP TABLE "GRD"."GRD_PARTICIPANTES"
/

DROP SEQUENCE "GRD"."SEQ_PARTICIPANTES"
/

ALTER TABLE "GRD"."GRD_PART_REUNIAO" ADD CONSTRAINT "FK_PartReuniao_PartId" FOREIGN KEY ("PartId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_PARTPREV_REUNIAO" ADD CONSTRAINT "FK_PartPrevReuniao_PartId" FOREIGN KEY ("PartId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_VOTOS" ADD CONSTRAINT "FK_Votos_Part" FOREIGN KEY ("ParticipanteId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE SET NULL
/

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (N'20220811212258_RemoveParticipanteModel', N'6.0.8')
/
