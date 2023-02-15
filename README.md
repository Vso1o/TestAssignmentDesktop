WPF application.
Solution contains 4 projects (Ignore TestAssignmentDesktop.Console as it was used to debug http requests)
Navigation is implemented with DataTemplate and using UserControls as pages. This approah can be used to implement common interface for all pages.
Home Page contains list of all currencies form CoinCap API. It can be ordered by any Property. 
Search is supported along with top-N limitation. Search is performed in both Codes and Names.
Button details will show page with currency details.
MVVM is used in WPF Part. Business and Core layers are responsible for work unrelated with Desktop App itself.
HttpUtil class is responsible for REST requests. It is practically unused, however it will provide ready implementation for any CRUD operations in case of need. API url can be changed as well.
Implemented feature which provides opportunity to convert one currency to another.