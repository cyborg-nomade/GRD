DROP INDEX "IX_GRD_PARTICIPANTES_UserId"
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_PARTICIPANTES' 
  and column_name = 'UserId' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_PARTICIPANTES" MODIFY "UserId" NUMBER(10) NULL';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_PARTICIPANTES" MODIFY "UserId" NUMBER(10)';
 end if;
end;
/

CREATE UNIQUE INDEX "GRD"."IX_GRD_PARTICIPANTES_UserId" ON "GRD"."GRD_PARTICIPANTES" ("UserId")
/

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (N'20220810202143_MakeParticipanteUserNullable', N'6.0.8')
/

