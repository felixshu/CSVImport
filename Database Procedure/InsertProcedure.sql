CREATE PROC addCustomer
    (
      @CustID UNIQUEIDENTIFIER ,
      @FirstName NVARCHAR(100) ,
      @LastName NVARCHAR(100) ,
      @PhoneNum NVARCHAR(100) ,
      @DoB DATE ,
      @Email NVARCHAR(100) ,
      @cust_address NVARCHAR(50) ,
      @cust_city NVARCHAR(50) ,
      @cust_state NVARCHAR(50) ,
      @cust_zip NVARCHAR(50) ,
      @cust_country NVARCHAR(50)
    )
AS
    BEGIN
        DECLARE @errMessage NCHAR(50);
        SET TRAN ISOLATION LEVEL SERIALIZABLE;
        BEGIN TRAN;
        BEGIN TRY
            INSERT  INTO [dbo].[customers]
                    ( [CustID] ,
                      [FirstName] ,
                      [LastName] ,
                      [PhoneNum] ,
                      [DoB] ,
                      [Email] ,
                      [cust_address] ,
                      [cust_city] ,
                      [cust_state] ,
                      [cust_zip] ,
                      [cust_country]
                    )
            VALUES  ( @CustID ,
                      @FirstName ,
                      @LastName ,
                      @PhoneNum ,
                      @DoB ,
                      @Email ,
                      @cust_address ,
                      @cust_city ,
                      @cust_state ,
                      @cust_zip ,
                      @cust_country
                    );
            COMMIT;
        END TRY
        BEGIN CATCH
            SELECT  ERROR_NUMBER() AS ErrorNumber ,
                    ERROR_MESSAGE() AS ErrorMessage;
            ROLLBACK;
        END CATCH;
    END;
GO


