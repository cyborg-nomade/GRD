ALTER TABLE "GRD"."GRD_ACAO_REUNIAO" DROP CONSTRAINT "FK_AcaoReuniao_AcaoId"
/

ALTER TABLE "GRD"."GRD_ACAO_REUNIAO" DROP CONSTRAINT "FK_AcaoReuniao_ReuniaoId"
/

ALTER TABLE "GRD"."GRD_PART_REUNIAO" DROP CONSTRAINT "FK_PartReuniao_PartId"
/

ALTER TABLE "GRD"."GRD_PART_REUNIAO" DROP CONSTRAINT "FK_PartReuniao_ReuniaoId"
/

ALTER TABLE "GRD"."GRD_PARTPREV_REUNIAO" DROP CONSTRAINT "FK_PartPrevReuniao_PartId"
/

ALTER TABLE "GRD"."GRD_PARTPREV_REUNIAO" DROP CONSTRAINT "FK_PartPrevReuniao_ReuId"
/

ALTER TABLE "GRD"."GRD_USER_GROUP" DROP CONSTRAINT "FK_UserGroup_GroupId"
/

ALTER TABLE "GRD"."GRD_USER_GROUP" DROP CONSTRAINT "FK_UserGroup_UserId"
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_VOTOS' 
  and column_name = 'ParticipanteId' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_VOTOS" MODIFY "ParticipanteId" NUMBER(10) NULL';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_VOTOS" MODIFY "ParticipanteId" NUMBER(10)';
 end if;
end;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_PROPOSICOES' 
  and column_name = 'CriadorId' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_PROPOSICOES" MODIFY "CriadorId" NUMBER(10) NULL';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_PROPOSICOES" MODIFY "CriadorId" NUMBER(10)';
 end if;
end;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_PROPOSICOES' 
  and column_name = 'AreaId' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_PROPOSICOES" MODIFY "AreaId" NUMBER(10) NULL';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_PROPOSICOES" MODIFY "AreaId" NUMBER(10)';
 end if;
end;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_LOGS_REUNIAO' 
  and column_name = 'RespId' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_REUNIAO" MODIFY "RespId" NUMBER(10) NULL';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_REUNIAO" MODIFY "RespId" NUMBER(10)';
 end if;
end;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_LOGS_PROPOSICAO' 
  and column_name = 'RespId' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_PROPOSICAO" MODIFY "RespId" NUMBER(10) NULL';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_PROPOSICAO" MODIFY "RespId" NUMBER(10)';
 end if;
end;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_LOGS_ACAO' 
  and column_name = 'RespId' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_ACAO" MODIFY "RespId" NUMBER(10) NULL';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_ACAO" MODIFY "RespId" NUMBER(10)';
 end if;
end;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_ANDAMENTOS' 
  and column_name = 'UserId' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_ANDAMENTOS" MODIFY "UserId" NUMBER(10) NULL';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_ANDAMENTOS" MODIFY "UserId" NUMBER(10)';
 end if;
end;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_ACOES' 
  and column_name = 'ResponsavelId' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_ACOES" MODIFY "ResponsavelId" NUMBER(10) NULL';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_ACOES" MODIFY "ResponsavelId" NUMBER(10)';
 end if;
end;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_ACOES' 
  and column_name = 'DiretoriaResId' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_ACOES" MODIFY "DiretoriaResId" NUMBER(10) NULL';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_ACOES" MODIFY "DiretoriaResId" NUMBER(10)';
 end if;
end;
/

ALTER TABLE "GRD"."GRD_ACAO_REUNIAO" ADD CONSTRAINT "FK_AcaoReuniao_AcaoId" FOREIGN KEY ("AcaoId") REFERENCES "GRD"."GRD_ACOES" ("Id") ON DELETE CASCADE
/

ALTER TABLE "GRD"."GRD_ACAO_REUNIAO" ADD CONSTRAINT "FK_AcaoReuniao_ReuniaoId" FOREIGN KEY ("ReuniaoId") REFERENCES "GRD"."GRD_REUNIOES" ("Id") ON DELETE CASCADE
/

ALTER TABLE "GRD"."GRD_PART_REUNIAO" ADD CONSTRAINT "FK_PartReuniao_PartId" FOREIGN KEY ("PartId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE CASCADE
/

ALTER TABLE "GRD"."GRD_PART_REUNIAO" ADD CONSTRAINT "FK_PartReuniao_ReuniaoId" FOREIGN KEY ("ReuniaoId") REFERENCES "GRD"."GRD_REUNIOES" ("Id") ON DELETE CASCADE
/

ALTER TABLE "GRD"."GRD_PARTPREV_REUNIAO" ADD CONSTRAINT "FK_PartPrevReuniao_PartId" FOREIGN KEY ("PartId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE CASCADE
/

ALTER TABLE "GRD"."GRD_PARTPREV_REUNIAO" ADD CONSTRAINT "FK_PartPrevReuniao_ReuId" FOREIGN KEY ("ReuId") REFERENCES "GRD"."GRD_REUNIOES" ("Id") ON DELETE CASCADE
/

ALTER TABLE "GRD"."GRD_USER_GROUP" ADD CONSTRAINT "FK_UserGroup_GroupId" FOREIGN KEY ("GroupId") REFERENCES "GRD"."GRD_GROUPS" ("Id") ON DELETE CASCADE
/

ALTER TABLE "GRD"."GRD_USER_GROUP" ADD CONSTRAINT "FK_UserGroup_UserId" FOREIGN KEY ("UserId") REFERENCES "GRD"."GRD_USERS" ("Id") ON DELETE CASCADE
/

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (N'20220815181344_FixNullabilityOfFKs', N'6.0.8')
/

