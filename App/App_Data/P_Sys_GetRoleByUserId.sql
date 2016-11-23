USE [DB]
GO
/****** Object:  StoredProcedure [dbo].[P_Sys_GetRoleByUserId]    Script Date: 02/21/2014 11:17:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[P_Sys_GetRoleByUserId]
@UserId varchar(50)
as
begin
--��ȡ�û��������Ľ�ɫ
select a.*,ISNULL(b.SysUserId,0) as flag from SysRole a left join
    SysRoleSysUser b 
    on a.Id = b.SysRoleId
    and b.SysUserId = @UserId
    order by b.SysUserId desc
end 