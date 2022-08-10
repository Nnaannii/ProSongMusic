CREATE PROCEDURE [dbo].[sp_song_select]
	@trasntype varchar(50) = '',
	@song_id int,
	@song_title varchar(50)='',
	@song_group varchar(50)='',
	@song_year  VARCHAR(50)='',
	@song_gene  VARCHAR(50)=''
AS

IF @trasntype = 'ALL'
BEGIN

	SELECT * FROM [dbo].[Song] (NOLOCK) 

	RETURN 0
END

IF @trasntype = 'ONE'
BEGIN

	SELECT * FROM [dbo].[Song] (NOLOCK) 
	WHERE Song_ID = @song_id

	RETURN 0
END

	
RETURN 0