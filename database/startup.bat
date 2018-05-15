sqlcmd -S (localdb)\MSSQLLocalDB -i drop_user.sql

sqlcmd -S (localdb)\MSSQLLocalDB -i create_user.sql

sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i drop_db.sql

sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i create_db.sql

sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Role.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\User.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Category.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\State.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Kind.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Image.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Country.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Membership.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\UsersInRoles.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Mail.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Phone.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Subcategory.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Area.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\City.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Location.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\Ad.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\AdsInCategories.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i tables\ImagesInAds.sql

sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i inserts\UserInsert.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i inserts\StateInsert.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i inserts\KindInsert.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i inserts\CountryInsert.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i inserts\AreaInsert.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i inserts\CityInsert.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i inserts\LocationInsert.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i inserts\AdInsert.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i inserts\CategoryInsert.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i inserts\SubcategoryInsert.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i inserts\AdsInCategoriesInsert.sql

sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i sp\_select\sp_select_category.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i sp\_select\sp_select_ad.sql

sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i sp\_filter\sp_filter_ad_by_categoryid.sql

sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i sp\_include\sp_include_category_on_subcategory_by_categoryid.sql

sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i sp\_get\sp_get_area_by_areaid.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i sp\_get\sp_get_city_by_cityid.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i sp\_get\sp_get_country_by_coyntryid.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i sp\_get\sp_get_location_by_locationid.sql
sqlcmd -S (localdb)\MSSQLLocalDB -U maxbr -P maxbro2968 -i sp\_get\sp_get_user_by_userid.sql

pause