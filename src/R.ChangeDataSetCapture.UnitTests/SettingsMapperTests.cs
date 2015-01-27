namespace R.DataSetChangeDetection.Strategies.UnitTests
{
    public class SettingsMapperTests
    {
        //private SettingsMapper _settingsMapper;

        public SettingsMapperTests()
        {
            //_settingsMapper = new SettingsMapper();
        }

        //[Fact]
        //public void Test_we_correctly_map_valid_BruteForce_Settings()
        //{
        //    //Setup
        //    var columList = new List<string>()
        //            {
        //                "STATUS"
        //            };

        //    var parameters = new Dictionary<string, object>()
        //        {
        //            {"ChangeDetectionStrategy", "BruteForce"},
        //            {"KeyColumnName", "ID_ITEM"},
        //            {"HashColumnList", columList}
        //        };
        //    //Execute
        //    var settings = _settingsMapper.GetSettings("TestDataSet", parameters);
        //    //Tests
        //    Assert.Equal(ChangeDetectionApproachType.BruteForce, settings.ChangeDetectionApproachType);
        //    Assert.Equal("ID_ITEM", settings.KeyColumnName);
        //    Assert.Equal(columList, settings.HashColumnList);
        //}

        //[Fact]
        //public void Test_we_throw_an_exception_when_no_DataSetName_is_provided()
        //{
        //    //Setup
        //    var columList = new List<string>()
        //            {
        //                "STATUS"
        //            };

        //    var parameters = new Dictionary<string, object>()
        //        {
        //            {"ChangeDetectionStrategy", "BruteForce"},
        //            {"KeyColumnName", "ID_ITEM"},
        //            {"HashColumnList", columList}
        //        };
        //    //Execute
        //    var ex = Assert.Throws<Exception>(() => _settingsMapper.GetSettings(null, parameters));
        //    Assert.Equal(ex.Message, "DataSetName is Required.");
        //}

        //[Fact]
        //public void Test_we_throw_an_exception_when_empty_parameters_are_provided()
        //{
        //    //Setup
        //    //Execute
        //    var ex = Assert.Throws<Exception>(() => _settingsMapper.GetSettings("SomeDataSetName", null));
        //    Assert.Equal(ex.Message, "Empty parameters list is not valid.  Requires at least a [ChangeDetectionStrategy].");
        //}

        //[Fact]
        //public void Test_we_throw_an_exception_if_we_dont_have_a_ChangeDetectionStrategy_property()
        //{
        //    //Setup
        //    var parameters = new Dictionary<string, object>()
        //        {
        //            {"IncorrectlyNamedParameter", "BruteForce"},
        //        };
        //    //Tests            
        //    var ex =Assert.Throws<Exception>(() => _settingsMapper.GetSettings("TestDataSet", parameters));
        //    Assert.Equal(ex.Message, "[ChangeDetectionStrategy] key is missing.");
        //}

        //[Fact]
        //public void Test_we_throw_an_exception_if_we_have_an_invalid_ChangeDetectionStrategy_specified()
        //{
        //    //Setup
        //    var parameters = new Dictionary<string, object>()
        //        {
        //            {"ChangeDetectionStrategy", "IncorrectlyNamedStrategy"},
        //        };
        //    //Tests            
        //    var ex = Assert.Throws<Exception>(() => _settingsMapper.GetSettings("TestDataSet", parameters));
        //    Assert.Equal(ex.Message, "Invalid [ChangeDetectionStrategy] selection.");
        //}

        //[Fact]
        //public void Test_we_throw_an_exception_if_we_are_missing_KeyColumnName_property()
        //{
        //    //Setup
        //    var parameters = new Dictionary<string, object>()
        //        {
        //            {"ChangeDetectionStrategy", "BruteForce"},                    
        //        };
        //    //Tests            
        //    var ex = Assert.Throws<Exception>(() => _settingsMapper.GetSettings("TestDataSet", parameters));
        //    Assert.Equal(ex.Message, "[KeyColumnName] is missing.");
        //}

        //[Fact]
        //public void Test_we_throw_an_exception_if_we_are_missing_HashColumnList_property()
        //{
        //    //Setup
        //    var parameters = new Dictionary<string, object>()
        //        {
        //            {"ChangeDetectionStrategy", "BruteForce"},   
        //            {"KeyColumnName", "ID_ITEM"},
        //        };
        //    //Tests            
        //    var ex = Assert.Throws<Exception>(() => _settingsMapper.GetSettings("TestDataSet", parameters));
        //    Assert.Equal(ex.Message, "[HashColumnList] key is missing");
        //}

        //[Fact]
        //public void Test_we_throw_an_exception_if_the_HashColumnList_is_not_a_list()
        //{
        //    //Setup
        //    var parameters = new Dictionary<string, object>()
        //        {
        //             {"ChangeDetectionStrategy", "BruteForce"},   
        //             {"KeyColumnName", "ID_ITEM"},
        //             {"HashColumnList", DateTime.Now}
        //        };
        //    //Tests            
        //    var ex = Assert.Throws<InvalidCastException>(() => _settingsMapper.GetSettings("TestDataSet", parameters));
        //    Assert.Equal(ex.Message, "Unable to cast [HashColumnList] to List<string>");
        //}

        //[Fact]
        //public void Test_we_handle_if_the_HashColumnList_is_serielized()
        //{
        //    //Setup
        //    var columList = new List<string>()
        //            {
        //                "STATUS"
        //            };

        //    var parameters = new Dictionary<string, object>()
        //        {
        //             {"ChangeDetectionStrategy", "BruteForce"},   
        //             {"KeyColumnName", "ID_ITEM"},
        //             {"HashColumnList", "[\r\n  \"STATUS\"\r\n]"}
        //        };         
        //    //Execute
        //    var settings = _settingsMapper.GetSettings("TestDataSet", parameters);
        //    //Tests
        //    Assert.Equal(ChangeDetectionApproachType.BruteForce, settings.ChangeDetectionApproachType);
        //    Assert.Equal("ID_ITEM", settings.KeyColumnName);
        //    Assert.Equal(columList, settings.HashColumnList);
        //}

        //[Fact]
        //public void Check_DeserializeParameters()
        //{
        //    var s = "[\r\n  \"STATUS\"\r\n]";
        //    var resval =_settingsMapper.DeserializeParameters(s);
        //    Assert.Equal(1, resval.Count);
        //}

       
    }
}
