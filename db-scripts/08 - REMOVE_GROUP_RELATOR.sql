ALTER TABLE "GRD"."GRD_USERS" DROP CONSTRAINT "FK_Andamentos_Users"
/

ALTER TABLE "GRD"."GRD_USERS" DROP CONSTRAINT "FK_Groups_User"
/

DROP INDEX "IX_GRD_USERS_AndamentoId"
/

ALTER TABLE "GRD"."GRD_USERS" DROP COLUMN "AndamentoId"
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_GROUPS' 
  and column_name = 'UserId' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_GROUPS" MODIFY "UserId" NUMBER(10) NULL';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_GROUPS" MODIFY "UserId" NUMBER(10)';
 end if;
end;
/

ALTER TABLE "GRD"."GRD_USERS" ADD CONSTRAINT "FK_Andamentos_Users" FOREIGN KEY ("Id") REFERENCES "GRD"."GRD_ANDAMENTOS" ("Id")
/

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (N'20220802143048_RemoveGroupRelator', N'6.0.7')
/

