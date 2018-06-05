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

sqlcmd -S %server% -U %user% -P %password% -i sp\_create\sp_create_type_imagestable.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_create\sp_create_type_categorytable.sql

sqlcmd -S %server% -U %user% -P %password% -i functions\func_get_kind_by_kindid.sql
sqlcmd -S %server% -U %user% -P %password% -i functions\func_get_location_by_cityid.sql
sqlcmd -S %server% -U %user% -P %password% -i functions\func_get_state_by_stateid.sql
sqlcmd -S %server% -U %user% -P %password% -i functions\func_select_ad.sql
sqlcmd -S %server% -U %user% -P %password% -i functions\func_get_kindid_by_type.sql
sqlcmd -S %server% -U %user% -P %password% -i functions\func_get_stateid_by_condition.sql

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
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_kind.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_state.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_area.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_city.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_select\sp_select_role.sql

sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_addetails_by_adid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_location_by_cityid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_user_by_userid.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_user_by_login.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_user_by_login_password.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_category_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_kind_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_state_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_area_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_city_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_country_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_get\sp_get_role_by_id.sql

sqlcmd -S %server% -U %user% -P %password% -i sp\_delete\sp_delete_ad_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_delete\sp_delete_category_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_delete\sp_delete_kind_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_delete\sp_delete_state_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_delete\sp_delete_area_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_delete\sp_delete_city_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_delete\sp_delete_country_by_id.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_delete\sp_delete_role_by_id.sql

sqlcmd -S %server% -U %user% -P %password% -i sp\_save\sp_save_image.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_save\sp_save_images.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_save\sp_save_addetails.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_save\sp_save_category.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_save\sp_save_kind.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_save\sp_save_state.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_save\sp_save_country.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_save\sp_save_role.sql

sqlcmd -S %server% -U %user% -P %password% -i sp\_search\sp_search_ad_by_name.sql
sqlcmd -S %server% -U %user% -P %password% -i sp\_search\sp_search_ad.sql

pause