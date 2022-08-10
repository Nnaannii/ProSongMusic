CREATE PROCEDURE [dbo].[sp_song_save]
	@trasntype varchar(50) = '',
	@song_id int,
	@song_title varchar(50)='',
	@song_group varchar(50)='',
	@song_year  VARCHAR(50)='',
	@song_gene  VARCHAR(50)=''
AS

IF @trasntype = 'SAVE'
BEGIN

	INSERT INTO [dbo].[Song] WITH(ROWLOCK) (Title,Song_Group,Song_Year,Gene)
	VALUES (@song_title,@song_group,@song_year,@song_gene)
RETURN 0
END

IF @trasntype = 'EDIT'
BEGIN

	UPDATE [dbo].[Song] WITH(ROWLOCK) SET  Title = @song_title,
	Song_Group = @song_group,
	Song_Year = @song_year,
	Gene =@song_gene
	WHERE Song_ID = @song_id

	RETURN 0
END
IF @trasntype = 'DELETE'
BEGIN

	DELETE [dbo].[Song] WITH(ROWLOCK)
	WHERE Song_ID = @song_id
RETURN 0
END

	
RETURN 0