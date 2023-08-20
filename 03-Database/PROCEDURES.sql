ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
ALTER SESSION SET NLS_DATE_FORMAT = 'DD/MM/YYYY';

--T?O M?I USER
CREATE OR REPLACE PROCEDURE GRANT_NEWUSER
(USER_NAME IN NVARCHAR2,PASS_WORD IN NVARCHAR2)
AUTHID CURRENT_USER 
AS
    TMP_COUNT INT;
BEGIN
    SELECT COUNT(*) INTO TMP_COUNT FROM ALL_USERS  WHERE UPPER(USERNAME) = UPPER(USER_NAME);
    IF(TMP_COUNT != 0) THEN
        RAISE_APPLICATION_ERROR(-20000,'USER DA TON TAI'); 
    ELSE
        IF PASS_WORD IS NOT NULL THEN
            EXECUTE IMMEDIATE('CREATE USER '|| USER_NAME||' IDENTIFIED BY '||PASS_WORD);
        ELSE
            EXECUTE IMMEDIATE('CREATE USER '|| USER_NAME);
        END IF;
        EXECUTE IMMEDIATE('GRANT CREATE SESSION TO '||USER_NAME);
    END IF;
END;
/
--XÃ“A USER
CREATE OR REPLACE PROCEDURE DROP_USER
(USER_NAME IN VARCHAR2)
AUTHID CURRENT_USER 
AS
    TMP_COUNT INT;
BEGIN
    SELECT COUNT(*) INTO TMP_COUNT FROM ALL_USERS WHERE UPPER(USERNAME) = UPPER(USER_NAME);
    IF(TMP_COUNT != 0) THEN
        EXECUTE IMMEDIATE('DROP USER '|| USER_NAME || ' CASCADE');
    ELSE 
         RAISE_APPLICATION_ERROR(-20000,'USER KHONG TON TAI'); 
    END IF;
END;
/
--T?O ROLE
CREATE OR REPLACE PROCEDURE GRANT_NEWROLE(ROLE_NAME IN VARCHAR2,PASS_WORD IN VARCHAR2)
AUTHID CURRENT_USER 
AS
    TMP_QUERY VARCHAR(100);
BEGIN
    IF(PASS_WORD IS NULL) THEN
        TMP_QUERY := 'CREATE ROLE '|| ROLE_NAME;
        EXECUTE IMMEDIATE (TMP_QUERY);
    ELSE
        TMP_QUERY := 'CREATE ROLE '|| ROLE_NAME||' IDENTIFIED BY '||PASS_WORD;
        EXECUTE IMMEDIATE (TMP_QUERY);
    END IF;
    EXCEPTION
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20000,'ROLE DA TON TAI'); 

END;
/

--XÃ“A ROLE
CREATE OR REPLACE PROCEDURE DROP_ROLE(ROLE_NAME IN VARCHAR2)
AUTHID CURRENT_USER 
AS
    TMP_QUERY VARCHAR(100);
    TMP_COUNT INT;
BEGIN
    SELECT COUNT(*) INTO TMP_COUNT FROM DBA_ROLES WHERE UPPER(ROLE) = UPPER(ROLE_NAME);
    IF TMP_COUNT > 0 THEN
        TMP_QUERY := 'DROP ROLE '|| ROLE_NAME;
        EXECUTE IMMEDIATE (TMP_QUERY);
    ELSE
        RAISE_APPLICATION_ERROR(-20000,'ROLE KHONG TON TAI');
    END IF;
         
END;
/
--CH?NH S?A PASSWORD USER
CREATE OR REPLACE PROCEDURE ALTER_USER(USER_NAME IN VARCHAR2,PASS_WORD IN VARCHAR2)
AUTHID CURRENT_USER
IS
TMP_COUNT INT;
BEGIN
    SELECT COUNT(*) INTO TMP_COUNT FROM ALL_USERS WHERE UPPER(USERNAME) = UPPER(USER_NAME);
    IF(TMP_COUNT != 0) THEN
        EXECUTE IMMEDIATE('ALTER USER '|| USER_NAME||' IDENTIFIED BY '||PASS_WORD);
    ELSE 
            RAISE_APPLICATION_ERROR(-20000,'USER KHONG TON TAI'); 
    END IF;
END;
/
--CH?NH S?A ROLE
CREATE OR REPLACE PROCEDURE ALTER_ROLE(ROLE_NAME IN VARCHAR2,PASS_WORD IN VARCHAR2)
AUTHID CURRENT_USER
IS
    TMP_COUNT INT;
    TMP_QUERY VARCHAR2(100);
BEGIN
    IF(PASS_WORD='') THEN
    TMP_QUERY :='ALTER ROLE '|| ROLE_NAME|| ' NOT IDENTIFIED';
    EXECUTE IMMEDIATE(TMP_QUERY);
    ELSIF(PASS_WORD!=' ') THEN
    TMP_QUERY :='ALTER ROLE '|| ROLE_NAME|| ' IDENTIFIED BY'|| PASS_WORD;
    END IF;
END;

/
--PHÃ‚N QUY?N CHO ROLE 
CREATE OR REPLACE PROCEDURE GRANT_PRIVS_TOROLE(ROLE_NAME IN VARCHAR2, PRIVS_NAME IN VARCHAR2,TABLE_NAME IN VARCHAR2)
AUTHID CURRENT_USER 
IS
TMP_QUERY VARCHAR2(100);
BEGIN 
    TMP_QUERY := 'GRANT '||PRIVS_NAME|| ' ON ' ||TABLE_NAME ||' TO ' ||ROLE_NAME;
    EXECUTE IMMEDIATE (TMP_QUERY); 
END;

/


--THU H?I QUY?N C?A ROLE
CREATE OR REPLACE PROCEDURE REVOKE_PRIVS_TOROLE(ROLE_NAME IN VARCHAR2, PRIV IN VARCHAR2,TABLE_NAME IN VARCHAR2)
AUTHID CURRENT_USER 
IS
TMP_QUERY VARCHAR(100);
TMP_COUNT INT;
EXCEPTION_USERNAME EXCEPTION;
BEGIN
SELECT COUNT(*) INTO TMP_COUNT  FROM DBA_TAB_PRIVS WHERE  UPPER(GRANTEE) = UPPER(ROLE_NAME) AND UPPER(TABLE_NAME) = UPPER(TABLE_NAME) AND UPPER(PRIVILEGE) = UPPER(PRIV);
IF(TMP_COUNT > 0) THEN
    TMP_QUERY:='REVOKE '||PRIV||' ON ' ||TABLE_NAME||' FROM ' ||ROLE_NAME;
    EXECUTE IMMEDIATE (TMP_QUERY);
ELSE
    RAISE_APPLICATION_ERROR(-20001, 'Quyen hoac Role khong ton tai');
END IF;
END;
/
--C?P QUY?N CHO USER
CREATE OR REPLACE PROCEDURE GRANT_PRIVS_TOUSER(USER_NAME IN VARCHAR2, PRIVS_NAME IN VARCHAR2,TABLE_NAME IN VARCHAR2,GRANT_OPTION IN VARCHAR2 )
AUTHID CURRENT_USER 
IS
TMP_COUNT INT;
TMP_QUERY VARCHAR2(100);
BEGIN 
SELECT COUNT(*) INTO TMP_COUNT FROM ALL_USERS WHERE UPPER(USERNAME) = UPPER(USER_NAME);
IF(TMP_COUNT!=0) THEN
    IF(GRANT_OPTION='NO') THEN
    TMP_QUERY:='GRANT '||PRIVS_NAME|| ' ON ' ||TABLE_NAME ||' TO ' ||USER_NAME;
    EXECUTE IMMEDIATE (TMP_QUERY);
   
    ELSIF(GRANT_OPTION='YES') THEN
    TMP_QUERY:='GRANT '||PRIVS_NAME|| ' ON ' ||TABLE_NAME ||' TO ' ||USER_NAME||' WITH GRANT OPTION' ;
    END IF;
EXECUTE IMMEDIATE (TMP_QUERY);
ELSE 
RAISE_APPLICATION_ERROR(-20000,'USER CHUA TON TAI');
END IF;
END;
/
--THU H?I QUY?N CHO USER
CREATE OR REPLACE PROCEDURE REVOKE_OBJECT_PRIVS_USER(USER_NAME IN VARCHAR2, PRIV IN VARCHAR2, A_OBJECT IN VARCHAR2)
AUTHID CURRENT_USER IS
TMP_QUERY VARCHAR(100);
TMP_COUNT INT;
BEGIN
SELECT COUNT(*) INTO TMP_COUNT  FROM DBA_TAB_PRIVS WHERE  UPPER(GRANTEE) = UPPER(USER_NAME) AND UPPER(TABLE_NAME) = UPPER(A_OBJECT) AND UPPER(PRIVILEGE) = UPPER(PRIV);
IF(TMP_COUNT > 0) THEN
    TMP_QUERY:='REVOKE '||PRIV||' ON ' ||A_OBJECT||' FROM ' ||USER_NAME;
    EXECUTE IMMEDIATE (TMP_QUERY);
ELSE
    RAISE_APPLICATION_ERROR(-20001, 'Quyen hoac User khong ton tai');
END IF;
END;
/

DROP TABLE DANGNHAP;
CREATE TABLE DANGNHAP (
      MANV VARCHAR2(10),
      SALT RAW(100),
      MATKHAU RAW(100),
      
      CONSTRAINT PK_DANGNHAP PRIMARY KEY(MANV)
);
/
-- Create a procedure to insert a record into DANGNHAP
CREATE OR REPLACE PROCEDURE INSERT_DANGNHAP_RECORD(
  p_MANV IN DANGNHAP.MANV%TYPE,
  p_SALT IN DANGNHAP.SALT%TYPE,
  p_MATKHAU IN RAW
) AS
BEGIN
  INSERT INTO DANGNHAP (MANV, SALT, MATKHAU)
  VALUES (p_MANV, p_SALT,  p_MATKHAU);
  
  COMMIT;
  DBMS_OUTPUT.PUT_LINE('Record inserted successfully.');
EXCEPTION
  WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE('Error inserting record: ' || SQLERRM);
    ROLLBACK;
END;
/


CREATE OR REPLACE FUNCTION pbkdf2
  ( p_password IN VARCHAR2
  , p_salt IN VARCHAR2
  , p_count IN INTEGER
  , p_key_length IN INTEGER )
RETURN RAW
IS
    l_block_count INTEGER;
    l_last RAW(32767);
    l_xorsum RAW(32767);
    l_result RAW(32767);
BEGIN
    l_block_count := CEIL(p_key_length / 20);  -- use 20 bytes for SHA1, 32 for SHA256, 64 for SHA512

    FOR i IN 1..l_block_count LOOP
        l_last := UTL_RAW.CONCAT(UTL_RAW.CAST_TO_RAW(p_salt), UTL_RAW.CAST_FROM_BINARY_INTEGER(i, UTL_RAW.BIG_ENDIAN));
        l_xorsum := NULL;

        FOR j IN 1..p_count LOOP
            l_last := DBMS_CRYPTO.MAC(l_last, DBMS_CRYPTO.HMAC_SH1, UTL_RAW.CAST_TO_RAW(p_password));
            -- use HMAC_SH256 for SHA256, HMAC_SH512 for SHA512

            IF l_xorsum IS NULL THEN
                l_xorsum := l_last;
            ELSE
                l_xorsum := UTL_RAW.BIT_XOR(l_xorsum, l_last);
            END IF;
        END LOOP;

        l_result := UTL_RAW.CONCAT(l_result, l_xorsum);
    END LOOP;

    RETURN UTL_RAW.SUBSTR(l_result, 1, p_key_length);
END pbkdf2;

/
CREATE OR REPLACE PROCEDURE encrypt_EACH_NHANVIEN(
    p_MANV   IN VARCHAR2)
AS
    p_TENNV     VARCHAR2(100);
    p_LUONG     VARCHAR2(50);
    p_PHUCAP    VARCHAR2(50);
    p_Password  VARCHAR2(50) := '';
    v_iv RAW(16) := DBMS_CRYPTO.RANDOMBYTES (16);
    --v_iv RAW(16):= UTL_RAW.CAST_TO_RAW('0123456789012345');
    v_key RAW(16);
    v_encrypted_luong RAW(2000);
    v_encrypted_phucap RAW(2000);
    
BEGIN

    SELECT LUONG, PHUCAP
    INTO  p_LUONG,p_PHUCAP
    FROM COMPANY.NHANVIEN
    WHERE MANV = p_MANV;
    
    P_Password := lower(p_MANV);
    
    v_key := pbkdf2(p_Password,v_iv,100,16);
   
    v_encrypted_luong := DBMS_CRYPTO.ENCRYPT(
        src => UTL_I18N.STRING_TO_RAW(p_LUONG, 'AL32UTF8'),
        typ => DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
        key => v_key,
        iv => v_iv
    );
    
    -- Encrypt the PHUCAP column
    v_encrypted_phucap := DBMS_CRYPTO.ENCRYPT(
        src => UTL_I18N.STRING_TO_RAW(p_PHUCAP, 'AL32UTF8'),
        typ => DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
        key => v_key,
        iv => v_iv
    );
--    INSERT INTO COMPANY.NHANVIEN (MANV, TENNV, PHAI, NGAYSINH, DIACHI, SDT, LUONG, PHUCAP, VAITRO, MANQL, PHG)
--    VALUES (p_MANV, p_TENNV, p_PHAI, p_NGAYSINH, p_DIACHI, p_SODT, v_encrypted_luong, v_encrypted_phucap, p_VAITRO, p_MANQL, p_PHG);

    UPDATE COMPANY.NHANVIEN
    SET LUONG = v_encrypted_luong, PHUCAP = v_encrypted_phucap
    WHERE MANV = p_MANV;
    
    BEGIN 
        INSERT_DANGNHAP_RECORD(p_MANV,v_iv, v_key);
    END;
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        -- Handle the exception or log the error
        DBMS_OUTPUT.PUT_LINE('Error inserting NHANVIEN record: ' || SQLERRM);
        ROLLBACK;
END;
/

CREATE OR REPLACE PROCEDURE encrypt_ALL_NHANVIEN
AS
    CURSOR c_NHANVIEN IS
        SELECT MANV FROM COMPANY.NHANVIEN;
BEGIN
    FOR rec IN c_NHANVIEN LOOP
        encrypt_EACH_NHANVIEN(rec.MANV);
    END LOOP;
END;
/


CREATE OR REPLACE FUNCTION DECRYPT_LUONG(
    p_MANV IN VARCHAR2,
    p_Password IN VARCHAR2
)
RETURN VARCHAR2
AS
    v_key RAW(16) := NULL;
    v_iv RAW(16):=NULL ;
    v_encrypted_luong RAW(2000);
    v_decrypted_luong VARCHAR2(2000);
BEGIN
    
    SELECT SALT  INTO v_iv 
    FROM COMPANY.DANGNHAP
    WHERE MANV = p_MANV;
    --DBMS_OUTPUT.PUT_LINE(v_key);
    
    v_key := pbkdf2(p_Password,v_iv,100,16);

    SELECT LUONG INTO v_encrypted_luong
    FROM COMPANY.NHANVIEN
    WHERE MANV = p_MANV;

    -- Decrypt the LUONG column
    v_decrypted_luong :=
        DBMS_CRYPTO.DECRYPT(
            src => v_encrypted_luong,
            typ => DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
            key => v_key,
            iv => v_iv
        );


    RETURN UTL_I18N.RAW_TO_CHAR(v_decrypted_luong);

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('No record found for MANV: ' || p_MANV);
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error decrypting NHANVIEN record: ' || SQLERRM);
END DECRYPT_LUONG;

/
CREATE OR REPLACE FUNCTION DECRYPT_PHUCAP(
    p_MANV IN VARCHAR2,
    p_Password IN VARCHAR2
)
RETURN VARCHAR2
AS
    v_key RAW(16) := NULL;
    v_iv RAW(16):=NULL ;
    v_encrypted_phucap RAW(2000);
    v_decrypted_phucap VARCHAR2(2000);
BEGIN
    
    SELECT SALT  INTO v_iv 
    FROM COMPANY.DANGNHAP
    WHERE MANV = p_MANV;
    --DBMS_OUTPUT.PUT_LINE(v_key);
    
    v_key := pbkdf2(p_Password,v_iv,100,16);

    SELECT PHUCAP INTO v_encrypted_phucap
    FROM COMPANY.NHANVIEN
    WHERE MANV = p_MANV;

    -- Decrypt the LUONG column
    v_decrypted_phucap :=
        DBMS_CRYPTO.DECRYPT(
            src => v_encrypted_phucap,
            typ => DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
            key => v_key,
            iv => v_iv
        );


    RETURN UTL_I18N.RAW_TO_CHAR(v_decrypted_phucap);

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('No record found for MANV: ' || p_MANV);
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error decrypting NHANVIEN record: ' || SQLERRM);
END DECRYPT_PHUCAP;

/
CREATE OR REPLACE PROCEDURE change_Key(
    v_MANV         IN VARCHAR2,
    old_Password   IN VARCHAR2,
    new_Password   IN VARCHAR2
)
AS
    v_key               RAW(50); -- STORE PASSWORD IN DANGNHAP TABLE
    v_salt              RAW(50); -- STORE SALT IN DANGNHAP TABLE
    v_encrypted_luong   RAW(2000);
    v_encrypted_phucap  RAW(2000);
    p_LUONG             VARCHAR2(50);
    p_PHUCAP            VARCHAR2(50);
    old_                VARCHAR2(50);
    new_                VARCHAR2(50);
BEGIN
    SELECT MATKHAU, SALT INTO v_key, v_salt FROM COMPANY.DANGNHAP WHERE MANV = UPPER(v_MANV);
    old_ := pbkdf2(old_Password, v_salt, 100, 16);
    dbms_output.put_line(old_);
    new_ := pbkdf2(new_Password, v_salt, 100, 16);
    dbms_output.put_line(new_);
    IF old_ = v_key THEN
        IF new_ = old_ THEN
            RAISE_APPLICATION_ERROR(-20001, 'MAT KHAU CU KHONG DUOC TRUNG MAT KHAU MOI');
        ELSE
            BEGIN
                SELECT LUONG, PHUCAP INTO p_LUONG, p_PHUCAP FROM COMPANY.NHANVIEN WHERE MANV = UPPER(v_MANV);
    
                p_LUONG := DECRYPT_LUONG(UPPER(v_MANV), old_Password);
                p_PHUCAP := DECRYPT_PHUCAP(UPPER(v_MANV), old_Password);
                
                v_key := new_;
       
                v_encrypted_luong := DBMS_CRYPTO.ENCRYPT(
                    src => UTL_I18N.STRING_TO_RAW(p_LUONG, 'AL32UTF8'),
                    typ => DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
                    key => v_key,
                    iv => v_salt
                );
                
                -- Encrypt the PHUCAP column
                v_encrypted_phucap := DBMS_CRYPTO.ENCRYPT(
                    src => UTL_I18N.STRING_TO_RAW(p_PHUCAP, 'AL32UTF8'),
                    typ => DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
                    key => v_key,
                    iv => v_salt
                );
                
                UPDATE COMPANY.DANGNHAP
                SET MATKHAU = v_key
                WHERE MANV = UPPER(v_MANV);
                
                UPDATE COMPANY.NHANVIEN
                SET LUONG = v_encrypted_luong, PHUCAP = v_encrypted_phucap
                WHERE MANV = UPPER(v_MANV);
                --EXECUTE IMMEDIATE 'alter session set "_ORACLE_SCRIPT"=TRUE';
                EXECUTE IMMEDIATE 'ALTER USER ' || UPPER(v_MANV) || ' IDENTIFIED BY ' || new_Password;
                COMMIT;
                EXCEPTION
                WHEN OTHERS THEN
                    DBMS_OUTPUT.PUT_LINE('Error decrypting NHANVIEN record: ' || SQLERRM);
                    ROLLBACK;
                
            END;
        END IF;
    ELSE
        RAISE_APPLICATION_ERROR(-20001, 'MAT KHAU CU KHONG DUNG');
        ROLLBACK;
    END IF;
END change_Key;
/


SET SERVEROUTPUT ON;
/*
    CS1: NHANVIEN ROLE
*/
CREATE OR REPLACE VIEW NHANVIEN$ AS
SELECT *
FROM COMPANY.NHANVIEN
WHERE UPPER(MANV) LIKE SYS_CONTEXT('USERENV','SESSION_USER');COMMIT;
/
CREATE OR REPLACE VIEW PHANCONG$ AS
SELECT *
FROM COMPANY.PHANCONG
WHERE UPPER(MANV) LIKE SYS_CONTEXT('USERENV','SESSION_USER');
/

CREATE OR REPLACE VIEW NHANVIEN_UPDATE AS
SELECT NGAYSINH,DIACHI,SDT
FROM COMPANY.NHANVIEN$;
/



/*
    CS2: QUANLI ROLE
*/

CREATE OR REPLACE VIEW NHANVIEN_HIDE AS
SELECT MANV,TENNV,PHAI,NGAYSINH,DIACHI,SDT,VAITRO,MANQL,PHG
FROM COMPANY.NHANVIEN;
/
CREATE OR REPLACE VIEW PHANCONG_QL AS
SELECT P.*,n.MANQL
FROM NHANVIEN n JOIN PHANCONG p
ON n.MANV = p.MANV;
/


CREATE OR REPLACE FUNCTION CS_QUANLI(
    schema_name IN VARCHAR2,
    table_name IN VARCHAR2
)
RETURN VARCHAR2 
AS
    count_ NUMBER;
BEGIN
    SELECT COUNT(*) INTO count_ FROM DBA_ROLE_PRIVS 
                                WHERE UPPER(GRANTEE) = SYS_CONTEXT('USERENV','SESSION_USER')
                                    AND GRANTED_ROLE = 'QL';
    IF count_ > 0 AND SYS_CONTEXT('USERENV','SESSION_USER') NOT LIKE 'COMPANY' THEN
        RETURN 'UPPER(MANQL) LIKE SYS_CONTEXT(''USERENV'',''SESSION_USER'')';
    ELSE
        RETURN '1=1';
    END IF;
END; 
/
---
BEGIN
   DBMS_RLS.ADD_POLICY(
      object_schema   => 'COMPANY',
      object_name     => 'NHANVIEN_HIDE',
      policy_name     => 'QUANLI_POLICY',
      function_schema => 'COMPANY',
      policy_function => 'CS_QUANLI',
      statement_types => 'SELECT'
   );
END;
/
BEGIN
   DBMS_RLS.ADD_POLICY(
      object_schema   => 'COMPANY',
      object_name     => 'PHANCONG_QL',
      policy_name     => 'QUANLI_POLICY',
      function_schema => 'COMPANY',
      policy_function => 'CS_QUANLI',
      statement_types => 'SELECT'
   );
END;
/


/*
    CS3: TRUONGPHONG ROLE
*/


CREATE OR REPLACE VIEW NHANVIEN_TP AS
SELECT n.*,p.TRPHG
FROM NHANVIEN_HIDE n JOIN PHONGBAN p
ON n.PHG = p.MAPB;

CREATE OR REPLACE FUNCTION CS_TRUONGPHONG(
    schema_name IN VARCHAR2,
    table_name IN VARCHAR2
)
RETURN VARCHAR2 
AS
    count_ NUMBER;
BEGIN
    SELECT COUNT(*) INTO count_ FROM DBA_ROLE_PRIVS 
                                WHERE UPPER(GRANTEE) = SYS_CONTEXT('USERENV','SESSION_USER')
                                    AND GRANTED_ROLE = 'TP';
    IF count_ > 0 AND SYS_CONTEXT('USERENV','SESSION_USER') NOT LIKE 'COMPANY' THEN
        RETURN 'UPPER(TRPHG) LIKE SYS_CONTEXT(''USERENV'',''SESSION_USER'')';
    ELSE
        RETURN '1=1';
    END IF;
END; 
/
BEGIN
   DBMS_RLS.ADD_POLICY(
      object_schema   => 'COMPANY',
      object_name     => 'NHANVIEN_TP',
      policy_name     => 'TRUONGPHONG_POLICY',
      function_schema => 'COMPANY',
      policy_function => 'CS_TRUONGPHONG',
      statement_types => 'SELECT'
   );
END;
/


CREATE OR REPLACE VIEW PHANCONG_TP AS
SELECT p.*
FROM NHANVIEN_TP n JOIN PHANCONG p
ON n.MANV = p.MANV;

/*
    CS4: TAICHINH ROLE
*/






/*
    CS5: NHANSU ROLE
*/
/
GRANT INSERT(MANV, TENNV, PHAI, NGAYSINH, DIACHI, SDT, VAITRO, MANQL,PHG) 
ON COMPANY.NHANVIEN TO NS;

GRANT UPDATE(MANV, TENNV, PHAI, NGAYSINH, DIACHI, SDT, VAITRO, MANQL,PHG) 
ON COMPANY.NHANVIEN TO NS;

ALTER SESSION SET NLS_DATE_FORMAT = 'DD/MM/YYYY';

CREATE OR REPLACE PROCEDURE UPDATE_NV (
  NGSINH IN VARCHAR,
  ST IN VARCHAR2,
  DCHI IN NVARCHAR2
)
AS
BEGIN 
  UPDATE COMPANY.NHANVIEN_UPDATE 
  SET NGAYSINH = NGSINH, SDT = ST, DIACHI = DCHI;
  COMMIT;
END;
/



CREATE OR REPLACE PROCEDURE INSERT_NV
(
    MANV IN VARCHAR2,
    TENNV IN VARCHAR2,
    PHAI IN NUMBER,
    NGAYSINH IN DATE, 
    DIACHI IN VARCHAR2,
    SDT IN VARCHAR2,
    VAITRO IN VARCHAR2,
    MAQL IN VARCHAR2,
    PHONG IN VARCHAR2 
)
AS
BEGIN 
    INSERT INTO COMPANY.NHANVIEN(MANV, TENNV, PHAI, NGAYSINH, DIACHI, SDT, VAITRO,MANQL, PHG)
    VALUES (MANV, TENNV, PHAI, NGAYSINH, DIACHI, SDT, VAITRO,MAQL, PHONG);
END;
/


CREATE OR REPLACE PROCEDURE UPDATE_NV_NS
(
    MA IN VARCHAR2,
    TEN IN VARCHAR2,
    GT IN NUMBER,
    NGSINH IN DATE, 
    DIACHI IN VARCHAR2,
    DT IN VARCHAR2,
    VTRO IN VARCHAR2,
    MAQL IN VARCHAR2,
    PHONG IN VARCHAR2 
)
AS
BEGIN 
    UPDATE COMPANY.NHANVIEN
    SET TENNV = TEN, PHAI = GT, NGAYSINH = NGSINH, SDT = DT, VAITRO = VTRO , MANQL= MAQL, PHG = PHONG 
    WHERE MANV = MA;
END;
/


CREATE OR REPLACE PROCEDURE INSERT_PB(
mapb IN VARCHAR2,
tenpb IN VARCHAR2,
trgph IN VARCHAR2)
AS 
BEGIN 
INSERT INTO COMPANY.PHONGBAN VALUES (mapb,tenpb,trgph);
COMMIT;
END;
/

CREATE OR REPLACE PROCEDURE UPDATE_PB_NS(
  pb IN VARCHAR2,
  ten IN VARCHAR2,
  tp IN VARCHAR2)
AS 
BEGIN 
  UPDATE COMPANY.PHONGBAN 
  SET TENPB = ten, TRPHG= tp
  WHERE MAPB = pb;
END;
/

CREATE OR REPLACE PROCEDURE DECRYPT_LUONG_temp(
    p_MANV IN VARCHAR2,
    p_Password IN VARCHAR2,
    p_decryptedLuong OUT VARCHAR2
)
AS
    v_key RAW(16) := NULL;
    v_iv RAW(16) := NULL;
    v_encrypted_luong RAW(2000);
    v_decrypted_luong VARCHAR2(2000);
BEGIN
    SELECT SALT  INTO v_iv 
    FROM COMPANY.DANGNHAP
    WHERE MANV = p_MANV;
    --DBMS_OUTPUT.PUT_LINE(v_key);
    
    v_key := pbkdf2(p_Password,v_iv,100,16);

    SELECT LUONG INTO v_encrypted_luong
    FROM COMPANY.NHANVIEN
    WHERE MANV = p_MANV;

    -- Decrypt the LUONG column
    v_decrypted_luong :=
        DBMS_CRYPTO.DECRYPT(
            src => v_encrypted_luong,
            typ => DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
            key => v_key,
            iv => v_iv
        );

    p_decryptedLuong := UTL_I18N.RAW_TO_CHAR(v_decrypted_luong);

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('No record found for MANV: ' || p_MANV);
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error decrypting NHANVIEN record: ' || SQLERRM);
END;
/

CREATE OR REPLACE PROCEDURE DECRYPT_PHUCAP_temp(
    p_MANV IN VARCHAR2,
    p_Password IN VARCHAR2,
    p_decryptedPC OUT VARCHAR2
)
AS
    v_key RAW(16) := NULL;
    v_iv RAW(16) := NULL;
    v_encrypted_phucap RAW(2000);
    v_decrypted_phucap VARCHAR2(2000);
BEGIN
    SELECT SALT  INTO v_iv 
    FROM COMPANY.DANGNHAP
    WHERE MANV = p_MANV;
    --DBMS_OUTPUT.PUT_LINE(v_key);
    
    v_key := pbkdf2(p_Password,v_iv,100,16);

    SELECT PHUCAP INTO v_encrypted_phucap
    FROM COMPANY.NHANVIEN
    WHERE MANV = p_MANV;

    -- Decrypt the LUONG column
    v_decrypted_phucap :=
        DBMS_CRYPTO.DECRYPT(
            src => v_encrypted_phucap,
            typ => DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
            key => v_key,
            iv => v_iv
        );

    p_decryptedPC := UTL_I18N.RAW_TO_CHAR(v_decrypted_phucap);

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('No record found for MANV: ' || p_MANV);
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error decrypting NHANVIEN record: ' || SQLERRM);
END;




/*
    CS6: TRUONGDEAN ROLE
*/





/*
    BGD ROLE
*/

/

COMMIT;
SELECT VALUE FROM V$OPTION WHERE PARAMETER = 'Unified Auditing';
--Cau A
BEGIN
   DBMS_FGA.DROP_POLICY
    (
        OBJECT_SCHEMA=>'COMPANY',
        OBJECT_NAME=>'PHANCONG',
        POLICY_NAME=>'A_AUDIT'
    );
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -28102 THEN
            RAISE;
        END IF;
END;
/

BEGIN
    DBMS_FGA.ADD_POLICY
    (
        OBJECT_SCHEMA => 'COMPANY',  
        OBJECT_NAME => 'PHANCONG',     
        POLICY_NAME => 'A_AUDIT',  
        AUDIT_COLUMN => 'THOIGIAN',  
        STATEMENT_TYPES => 'UPDATE',   
        ENABLE => TRUE                 
    );
END;
/

--Cau B 
BEGIN
   DBMS_FGA.DROP_POLICY
    (
        OBJECT_SCHEMA=>'COMPANY',
        OBJECT_NAME=>'NHANVIEN',
        POLICY_NAME=>'b_audit'
    );
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -28102 THEN
            RAISE;
        END IF;
END;
/
BEGIN
DBMS_FGA.ADD_POLICY
    (OBJECT_SCHEMA=>'COMPANY', 
    OBJECT_NAME=>'NHANVIEN', 
    POLICY_NAME=>'b_audit', 
    AUDIT_COLUMN => 'LUONG,PHUCAP',
    AUDIT_CONDITION=>'MANV != SYS_CONTEXT(''USERENV'',''SESSION_USER'')',
    STATEMENT_TYPES=>'SELECT',
    ENABLE => TRUE
    --POLICY_OWNER => 'COMPANY',
    --AUDIT_TRAIL => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
    );
END;
/

--Cau c
CREATE TABLE aud_LUONG (
    username    VARCHAR2(30),
    action      VARCHAR2(6),
    nhanvien    VARCHAR2(5),
    column_name VARCHAR2(255),
    call_stack  VARCHAR2(4000),
    client_id   VARCHAR2(255),
    old_value   VARCHAR2(100),
    new_value   VARCHAR2(100),
    action_date DATE DEFAULT SYSDATE
);


/
CREATE OR REPLACE PROCEDURE audit_LUONG(
    p_username      IN  VARCHAR2,
    p_action        IN  VARCHAR2,
    p_NHANVIEN      IN  VARCHAR2,
    p_column_name   IN  VARCHAR2,
    p_old_value     IN  VARCHAR2,
    p_new_value     IN  VARCHAR2)
AS
BEGIN
    INSERT INTO aud_LUONG 
    VALUES(p_username,p_action,p_NHANVIEN,p_column_name,
    DBMS_UTILITY.format_call_stack,SYS_CONTEXT('userenv','client_identifier'),
    p_old_value,p_new_value,SYSDATE);
END;

/
CREATE OR REPLACE PROCEDURE show_aud_LUONG_PHUCAP
AS
BEGIN
    FOR rec IN (SELECT * FROM aud_LUONG ORDER BY action_date DESC)
    
    LOOP
        DBMS_OUTPUT.put_line('User:      ' || rec.username);
        DBMS_OUTPUT.put_line('Client ID: ' || rec.client_id);
        DBMS_OUTPUT.put_line('Action:    ' || rec.action);
        DBMS_OUTPUT.put_line('NhanVien:  ' || rec.nhanvien);
        DBMS_OUTPUT.put_line('Column:    ' || rec.column_name);
        DBMS_OUTPUT.put_line('Old Value: ' || rec.old_value);
        DBMS_OUTPUT.put_line('New Value: ' || rec.new_value);
        DBMS_OUTPUT.put_line('Date:      ' || TO_CHAR(rec.action_date,'Mon-DD-YY HH24:MI'));
        
        DBMS_OUTPUT.put_line('---------------------------------------------');
    END LOOP;
END;
/
CREATE OR REPLACE TRIGGER update_LUONG_trig
BEFORE UPDATE OF LUONG
ON COMPANY.NHANVIEN
FOR EACH ROW
DECLARE
    count_  NUMBER;
BEGIN
    SELECT COUNT(*) INTO count_ FROM DBA_ROLE_PRIVS 
                                WHERE UPPER(GRANTEE) = SYS_CONTEXT('USERENV','SESSION_USER')
                                    AND GRANTED_ROLE = 'TC';

    IF count_ = 0 or UPPER(SYS_CONTEXT('USERENV','SESSION_USER')) LIKE ('COMPANY') THEN
        audit_LUONG (
            p_username => USER,
            p_action => 'UPDATE',
            p_NHANVIEN => :OLD.MANV,
            p_column_name => 'LUONG',
            p_old_value => TO_CHAR (:OLD.LUONG),
            p_new_value => TO_CHAR (:NEW.LUONG)
        );
    END IF;
END;
/

CREATE OR REPLACE TRIGGER update_PHUCAP_trig
BEFORE UPDATE OF PHUCAP
ON COMPANY.NHANVIEN
FOR EACH ROW
DECLARE
    count_  NUMBER;
BEGIN
    SELECT COUNT(*) INTO count_ FROM DBA_ROLE_PRIVS 
                                WHERE UPPER(GRANTEE) = SYS_CONTEXT('USERENV','SESSION_USER')
                                    AND GRANTED_ROLE = 'TC';

    IF count_ = 0 or UPPER(SYS_CONTEXT('USERENV','SESSION_USER')) LIKE ('COMPANY') THEN
        audit_LUONG (
            p_username => USER,
            p_action => 'UPDATE',
            p_NHANVIEN => :OLD.MANV,
            p_column_name => 'PHUCAP',
            p_old_value => TO_CHAR (:OLD.PHUCAP),
            p_new_value => TO_CHAR (:NEW.PHUCAP)
        );
    END IF;
END;
/

-- ten DN la MANV, khoa Bi Mat dung de ma hoa LUONG va PHUCAP
--TRY PROFILE QUAN LI MAT KHAU 
-- Create the DANGNHAP table


CREATE TABLE NHANVIEN_TC(
    MANV VARCHAR(10) NOT NULL,
    TENNV NVARCHAR2(100),
    PHAI NUMBER(1) NOT NULL,
    NGAYSINH DATE,
    DIACHI NVARCHAR2(100),
    SDT VARCHAR(10) UNIQUE,
    LUONG VARCHAR2(50),
    PHUCAP VARCHAR2(50),
    VAITRO NVARCHAR2(50),
    MANQL VARCHAR(10),
    PHG VARCHAR(10),
    
    CONSTRAINT PK_NHANVIEN_TC PRIMARY KEY(MANV)
);

CREATE OR REPLACE PROCEDURE DECRYPT_LUONG_WITHOUT_PASS 
IS
    v_key RAW(16) := NULL;
    v_iv RAW(16):=NULL ;
    v_encrypted_luong RAW(2000);
    v_encrypted_phucap RAW(2000);
    v_decrypted_luong VARCHAR2(2000);
    v_decrypted_phucap VARCHAR2(2000);
    v_MANV VARCHAR(10);
    v_TENNV NVARCHAR2(100);
    v_PHAI NUMBER(1);
    v_NGAYSINH DATE;
    v_DIACHI NVARCHAR2(100);
    v_SDT VARCHAR(10);
    v_LUONG VARCHAR2(50);
    v_PHUCAP VARCHAR2(50);
    v_VAITRO NVARCHAR2(50);
    v_MANQL VARCHAR(10);
    v_PHG VARCHAR(10);
    
    CURSOR cur IS SELECT MANV,TENNV,PHAI,NGAYSINH,DIACHI,SDT,LUONG,PHUCAP,VAITRO,MANQL,PHG
                  FROM COMPANY.NHANVIEN ORDER BY MANV ASC;
    
BEGIN
    DELETE FROM NHANVIEN_TC;
    OPEN cur;
    LOOP
        FETCH cur INTO v_MANV,v_TENNV,v_PHAI,v_NGAYSINH,v_DIACHI,v_SDT,v_LUONG,v_PHUCAP,v_VAITRO,v_MANQL,v_PHG;
        EXIT WHEN cur%NOTFOUND;
        BEGIN
            SELECT SALT,MATKHAU  INTO v_iv,v_key
            FROM COMPANY.DANGNHAP
            WHERE MANV = v_MANV;
            
            -- Decrypt the LUONG column
            v_decrypted_luong :=
                DBMS_CRYPTO.DECRYPT(
                    src => v_LUONG,
                    typ => DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
                    key => v_key,
                    iv => v_iv
                );
        
            -- Decrypt the PHUCAP column
            v_decrypted_phucap := 
                DBMS_CRYPTO.DECRYPT(
                    src => v_PHUCAP,
                    typ => DBMS_CRYPTO.ENCRYPT_AES128 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5,
                    key => v_key,
                    iv => v_iv
            );
            INSERT INTO NHANVIEN_TC VALUES(v_MANV,v_TENNV,v_PHAI,v_NGAYSINH,v_DIACHI,v_SDT,UTL_I18N.RAW_TO_CHAR(v_decrypted_luong),UTL_I18N.RAW_TO_CHAR(v_decrypted_phucap),v_VAITRO,v_MANQL,v_PHG);  
            COMMIT;
            EXCEPTION
                -- Handle any exceptions and exit the loop
                WHEN OTHERS THEN
                    DBMS_OUTPUT.PUT_LINE('Error occurred: ' || SQLERRM);
                    EXIT;
            END;
    END LOOP;
    CLOSE cur;
END DECRYPT_LUONG_WITHOUT_PASS;
/
CREATE OR REPLACE PROCEDURE update_encrypted_luong(
    p_MANV IN NHANVIEN.MANV%TYPE,
    p_LUONG IN NHANVIEN.LUONG%TYPE
)
IS
BEGIN
    -- Retrieve the encryption key and initialization vector from DANGNHAP table
    UPDATE COMPANY.NHANVIEN
    SET LUONG = p_LUONG
    WHERE MANV = p_MANV;
    COMMIT;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        -- Handle the exception if the MANV is not found
        RAISE_APPLICATION_ERROR(-20001, 'MANV not found.');
    WHEN OTHERS THEN
        -- Handle other exceptions
        RAISE_APPLICATION_ERROR(-20002, 'An error occurred: ' || SQLERRM);
END;
/

CREATE OR REPLACE PROCEDURE update_encrypted_phucap(
    p_MANV IN NHANVIEN.MANV%TYPE,
    p_PHUCAP IN NHANVIEN.PHUCAP%TYPE
)
IS
BEGIN
    -- Retrieve the encryption key and initialization vector from DANGNHAP table
    UPDATE COMPANY.NHANVIEN
    SET PHUCAP = p_PHUCAP
    WHERE MANV = p_MANV;
    COMMIT;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        -- Handle the exception if the MANV is not found
        RAISE_APPLICATION_ERROR(-20001, 'MANV not found.');
    WHEN OTHERS THEN
        -- Handle other exceptions
        RAISE_APPLICATION_ERROR(-20002, 'An error occurred: ' || SQLERRM);
END;
/

COMMIT;


