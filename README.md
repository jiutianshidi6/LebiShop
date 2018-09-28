# LebiShop 乐彼多语言网上商城系统
采用ASP.NET 4.0（C#）和AJAX技术开发，完全具备搭建超大型网上商城的整体技术框架和应用层次。系统具备安全、稳定、高效、扩展性强、操作简便等众多优点，是您搭建网上商城的不二选择，系统内置四十几种国家语言，前台和后台均支持语言切换。<br/><br/>
采用Lebi多层结构开发，html模板文件和cs文件分离，自动生成aspx文件，不论是开发还是维护都变得更加轻松。<br/>
模板支持标签引用和c#语法，不论是开发人员还是前端设计人员都极易上手，多级的模板结构让个性化重写也变得随意。<br/>
数据库推荐使用MSSQL2012及以上版本。<br/>首次访问后台，需要先在浏览器输入/admin/updatepage.aspx，显示OK后即可访问后台/admin/进行登录，默认账号和密码均为admin。<br/><br/>

# 工程结构：
Shop 网站页面相关类库<br/>
Shop/PageBase .cs文件<br/>
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

模板结构 http://www.lebi.cn/faq/info.aspx?id=99<br/>
模板语法 http://www.lebi.cn/faq/info.aspx?id=98<br/>
个人学习研究免费使用，商业使用请购买商业授权 http://www.lebi.cn/opensource/<br/>
