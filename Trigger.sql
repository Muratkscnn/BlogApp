--Create Trigger AddBlogInRaytingTable
--On Blogs
--After Insert
--As
--Declare @ID int
--Select @ID=BlogID from inserted
--Insert Into BlogRaytings (BlogID,BlogTotalScore,BlogRaytingCount)
--Values (@ID,0,0)

Create Trigger AddScoreInComment
On Comments
After Insert
As
Declare @ID int
Declare @Score int
Declare @RaytingCount int
Select @ID=BlogID,@Score=BlogScore from inserted
Update BlogRaytings Set BlogTotalScore=BlogTotalScore+@Score,BlogRaytingCount+=1
Where BlogID=@ID