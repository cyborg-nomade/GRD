CREATE SEQUENCE "GRD"."SEQ_ACOES" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

CREATE SEQUENCE "GRD"."SEQ_ANDAMENTOS" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

CREATE SEQUENCE "GRD"."SEQ_GROUPS" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

CREATE SEQUENCE "GRD"."SEQ_LOGS_ACAO" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

CREATE SEQUENCE "GRD"."SEQ_LOGS_PROPOSICAO" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

CREATE SEQUENCE "GRD"."SEQ_LOGS_REUNIAO" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

CREATE SEQUENCE "GRD"."SEQ_PARTICIPANTES" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

CREATE SEQUENCE "GRD"."SEQ_PROPOSICOES" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

CREATE SEQUENCE "GRD"."SEQ_RESOLUCOES" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

CREATE SEQUENCE "GRD"."SEQ_REUNIOES" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

CREATE SEQUENCE "GRD"."SEQ_USERS" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

CREATE SEQUENCE "GRD"."SEQ_VOTOS" START WITH 1 INCREMENT BY 10 NOMINVALUE NOMAXVALUE NOCYCLE
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_VOTOS'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_VOTOS" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_VOTOS' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_VOTOS" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_VOTOS" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_USERS'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_USERS" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_USERS' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_USERS" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_USERS" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_REUNIOES'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_REUNIOES" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_REUNIOES' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_REUNIOES" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_REUNIOES" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_RESOLUCOES'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_RESOLUCOES" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_RESOLUCOES' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_RESOLUCOES" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_RESOLUCOES" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_PROPOSICOES'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_PROPOSICOES" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_PROPOSICOES' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_PROPOSICOES" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_PROPOSICOES" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_PARTICIPANTES'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_PARTICIPANTES" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_PARTICIPANTES' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_PARTICIPANTES" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_PARTICIPANTES" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_LOGS_REUNIAO'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_LOGS_REUNIAO" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_LOGS_REUNIAO' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_REUNIAO" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_REUNIAO" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_LOGS_PROPOSICAO'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_LOGS_PROPOSICAO" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_LOGS_PROPOSICAO' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_PROPOSICAO" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_PROPOSICAO" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_LOGS_ACAO'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_LOGS_ACAO" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_LOGS_ACAO' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_ACAO" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_LOGS_ACAO" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_GROUPS'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_GROUPS" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_GROUPS' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_GROUPS" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_GROUPS" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_ANDAMENTOS'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_ANDAMENTOS" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_ANDAMENTOS' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_ANDAMENTOS" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_ANDAMENTOS" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

DECLARE
   v_Count INTEGER;
BEGIN
  SELECT COUNT(*) INTO v_Count
  FROM ALL_TAB_IDENTITY_COLS T
  WHERE T.TABLE_NAME = N'GRD_ACOES'
  AND T.COLUMN_NAME = 'Id';
  IF v_Count > 0 THEN
    EXECUTE IMMEDIATE 'ALTER  TABLE "GRD_ACOES" MODIFY "Id" DROP IDENTITY';
  END IF;
END;
/

declare
   l_nullable all_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from all_tab_columns 
  where table_name = 'GRD_ACOES' 
  and column_name = 'Id' 
   and owner = 'GRD'; 
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_ACOES" MODIFY "Id" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "GRD"."GRD_ACOES" MODIFY "Id" NUMBER(10) NOT NULL';
 end if;
end;
/

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (N'20220802173546_FixPrimaryKeys', N'6.0.7')
/

