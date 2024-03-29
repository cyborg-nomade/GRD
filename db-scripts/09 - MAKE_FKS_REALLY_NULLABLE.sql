﻿ALTER TABLE "GRD"."GRD_ACAO_REUNIAO" DROP CONSTRAINT "FK_AcaoReuniao_ReuniaoId"
/

ALTER TABLE "GRD"."GRD_ACOES" DROP CONSTRAINT "FK_Acoes_Group"
/

ALTER TABLE "GRD"."GRD_ACOES" DROP CONSTRAINT "FK_Acoes_User"
/

ALTER TABLE "GRD"."GRD_ANDAMENTOS" DROP CONSTRAINT "FK_Andamentos_Users"
/

ALTER TABLE "GRD"."GRD_LOGS_ACAO" DROP CONSTRAINT "FK_LogsA_Acao"
/

ALTER TABLE "GRD"."GRD_LOGS_ACAO" DROP CONSTRAINT "FK_LogsA_User"
/

ALTER TABLE "GRD"."GRD_LOGS_PROPOSICAO" DROP CONSTRAINT "FK_LogsP_Proposicao"
/

ALTER TABLE "GRD"."GRD_LOGS_PROPOSICAO" DROP CONSTRAINT "FK_LogsP_User"
/

ALTER TABLE "GRD"."GRD_LOGS_REUNIAO" DROP CONSTRAINT "FK_LogsR_Reuniao"
/

ALTER TABLE "GRD"."GRD_LOGS_REUNIAO" DROP CONSTRAINT "FK_LogsR_User"
/

ALTER TABLE "GRD"."GRD_PART_REUNIAO" DROP CONSTRAINT "FK_PartReuniao_ReuniaoId"
/

ALTER TABLE "GRD"."GRD_PARTICIPANTES" DROP CONSTRAINT "FK_Part_Group"
/

ALTER TABLE "GRD"."GRD_PARTICIPANTES" DROP CONSTRAINT "FK_Part_User"
/

ALTER TABLE "GRD"."GRD_PARTPREV_REUNIAO" DROP CONSTRAINT "FK_PartPrevReuniao_ReuId"
/

ALTER TABLE "GRD"."GRD_PROPOSICOES" DROP CONSTRAINT "FK_Proposicoes_Group"
/

ALTER TABLE "GRD"."GRD_PROPOSICOES" DROP CONSTRAINT "FK_Proposicoes_User"
/

ALTER TABLE "GRD"."GRD_PROPOSICOES" DROP CONSTRAINT "FK_Reunioes_Prop"
/

ALTER TABLE "GRD"."GRD_PROPOSICOES" DROP CONSTRAINT "FK_Reunioes_PropPrev"
/

ALTER TABLE "GRD"."GRD_USER_GROUP" DROP CONSTRAINT "FK_UserGroup_UserId"
/

ALTER TABLE "GRD"."GRD_VOTOS" DROP CONSTRAINT "FK_Votos_Part"
/

ALTER TABLE "GRD"."GRD_ACAO_REUNIAO" ADD CONSTRAINT "FK_AcaoReuniao_ReuniaoId" FOREIGN KEY ("ReuniaoId") REFERENCES "GRD"."GRD_REUNIOES" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_ACOES" ADD CONSTRAINT "FK_Acoes_Group" FOREIGN KEY ("DiretoriaResId") REFERENCES "GRD"."GRD_GROUPS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_ACOES" ADD CONSTRAINT "FK_Acoes_User" FOREIGN KEY ("ResponsavelId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_ANDAMENTOS" ADD CONSTRAINT "FK_Andamentos_Users" FOREIGN KEY ("UserId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_LOGS_ACAO" ADD CONSTRAINT "FK_LogsA_Acao" FOREIGN KEY ("AcaoId") REFERENCES "GRD"."GRD_ACOES" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_LOGS_ACAO" ADD CONSTRAINT "FK_LogsA_User" FOREIGN KEY ("RespId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_LOGS_PROPOSICAO" ADD CONSTRAINT "FK_LogsP_Proposicao" FOREIGN KEY ("PropId") REFERENCES "GRD"."GRD_PROPOSICOES" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_LOGS_PROPOSICAO" ADD CONSTRAINT "FK_LogsP_User" FOREIGN KEY ("RespId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_LOGS_REUNIAO" ADD CONSTRAINT "FK_LogsR_Reuniao" FOREIGN KEY ("ReuniaoId") REFERENCES "GRD"."GRD_REUNIOES" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_LOGS_REUNIAO" ADD CONSTRAINT "FK_LogsR_User" FOREIGN KEY ("RespId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_PART_REUNIAO" ADD CONSTRAINT "FK_PartReuniao_ReuniaoId" FOREIGN KEY ("ReuniaoId") REFERENCES "GRD"."GRD_REUNIOES" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_PARTICIPANTES" ADD CONSTRAINT "FK_Part_Group" FOREIGN KEY ("AreaId") REFERENCES "GRD"."GRD_GROUPS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_PARTICIPANTES" ADD CONSTRAINT "FK_Part_User" FOREIGN KEY ("UserId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_PARTPREV_REUNIAO" ADD CONSTRAINT "FK_PartPrevReuniao_ReuId" FOREIGN KEY ("ReuId") REFERENCES "GRD"."GRD_REUNIOES" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_PROPOSICOES" ADD CONSTRAINT "FK_Proposicoes_Group" FOREIGN KEY ("AreaId") REFERENCES "GRD"."GRD_GROUPS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_PROPOSICOES" ADD CONSTRAINT "FK_Proposicoes_User" FOREIGN KEY ("CriadorId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_PROPOSICOES" ADD CONSTRAINT "FK_Reunioes_Prop" FOREIGN KEY ("ReuniaoId") REFERENCES "GRD"."GRD_REUNIOES" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_PROPOSICOES" ADD CONSTRAINT "FK_Reunioes_PropPrev" FOREIGN KEY ("ReuniaoId1") REFERENCES "GRD"."GRD_REUNIOES" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_USER_GROUP" ADD CONSTRAINT "FK_UserGroup_UserId" FOREIGN KEY ("UserId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE SET NULL
/

ALTER TABLE "GRD"."GRD_VOTOS" ADD CONSTRAINT "FK_Votos_Part" FOREIGN KEY ("ParticipanteId") REFERENCES "GRD"."GRD_PARTICIPANTES" ("Id") ON DELETE SET NULL
/

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (N'20220810141340_MakeFKReallyNullable', N'6.0.7')
/

