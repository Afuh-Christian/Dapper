CREATE PROCEDURE [dbo].[user_Delete]
	@Id int 
AS
BEGIN  
	DELETE 
	FROM dbo.[User] WHERE Id = @Id ; 
END 


	
