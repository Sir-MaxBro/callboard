set user="max_bro"
set password="1111"
set server="DESKTOP-4I1O878\SQLEXPRESS"

sqlcmd -S %server% -U %user% -P %password% -i drop_db.sql
sqlcmd -S %server% -i drop_user.sql

sqlcmd -S %server% -i create_user.sql
sqlcmd -S %server% -i create_db.sql

sqlcmd -S %server% -U %user% -P %password% -i create_db_user.sql

sqlcmd -S %server% -U %user% -P %password% -i tables\Role.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\User.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\Category.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\State.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\Kind.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\Image.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\Country.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\Membership.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\UsersInRoles.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\Mail.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\Phone.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\Area.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\City.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\Ad.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\AdDetails.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\AdsInCategories.sql
sqlcmd -S %server% -U %user% -P %password% -i tables\ImagesInAds.sql

sqlcmd -S %server% -U %user% -P %password% -i inserts\UserInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\PhoneInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\MailInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\StateInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\KindInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\CountryInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\AreaInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\CityInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\AdInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\ImageInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\ImagesInAdsInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\AdDetailsInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\CategoryInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\AdsInCategoriesInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\MembershipInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\RoleInsert.sql
sqlcmd -S %server% -U %user% -P %password% -i inserts\UsersInRolesInsert.sql

sqlcmd -S %server% -U %user% -P %password% -i functions\func_get_kind_by_kindid.sql
sqlcmd -S %server% -U %user% -P %password% -i functions\func_get_location_by_cityid.sql
sqlcmd -S %server% -U %user% -P %password% -i functions\func_get_state_by_stateid.sql
sqlcmd -S %server% -U %user% -P %password% -i functions\func_select_ad.sql

sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_category.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_ad_by_categoryid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_ad.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_image_by_adid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_mail_by_userid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_phone_by_userid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_subcategory_by_parentid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_area_by_countryid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_city_by_areaid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_country.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_role_by_userid.sql

sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_addetails_by_adid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_area_by_areaid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_city_by_cityid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_country_by_countryid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_location_by_cityid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_user_by_userid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_user_by_login.sql

sqlcmd -S %server% -U %user% -P %password% -i sp\_check\sp_check_membership.sql

pause