# LebiShop 乐彼多语言网上商城系统
采用ASP.NET 4.0（C#）和AJAX技术开发，完全具备搭建超大型网上商城的整体技术框架和应用层次。系统具备安全、稳定、高效、扩展性强、操作简便等众多优点，是您搭建网上商城的不二选择

# 工程结构：
Shop 网站页面相关类库<br/>
Shop.Bussiness 主要业务处理类库<br/>
Shop.DataAccess 数据访问类库<br/>
Shop.Model 数据库模型以及其它模型类库<br/>
Shop.Platform 第三方登录相关<br/>
Shop.Tools 工具类库<br/>

# 文件结构：
Shop<br/>
    admin 后台文件夹-系统自动生成<br/>
ajax AJAX数据操作文件夹-系统自动生成<br/>
api API文件夹-系统自动生成<br/>
back SQL数据库备份文件夹<br/>
config 系统配置文件文件夹 用于存放系统、插件配置文件<br/>
editor 网页编辑器文件夹<br/>
inc 块文件文件夹<br/>
install 安装向导文件夹<br/>
onlinepay 在线支付接口文件夹<br/>
pagebase 页面 cs 文件夹<br/>
admin 后台文件夹<br/>

Shop.Bussiness<br/>
DB： 此目录文件全部由LebiShop 代码生成工具生成，不可以手工修改<br/>
PageBase： 网站页面的主要基类文件<br/>

Shop.DataAccess<br/>
Auto：<br/>
数据库底层的增删改查操作，支持包括 sqlserver 和access 两种形式<br/>
此目录文件全部由LebiShop 代码生成工具生成，不可以手工修改<br/>
Base： 数据层基类<br/><br/>

Shop.Model<br/>
Auto：<br/>
数据库模型<br/>
此目录文件全部有 LebiShop 代码生成工具生成，不可以手工修改<br/><br/>

Shop.Platform<br/>
Model：<br/>
第三方接口类<br/><br/>

Shop.Tools<br/>
常用功能类<br/><br/>
