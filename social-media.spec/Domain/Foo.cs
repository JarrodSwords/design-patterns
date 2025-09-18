//using FluentAssertions;
//using Moq;
//using System.Drawing;
//using static System.Net.Mime.MediaTypeNames;

//namespace Examples.SocialMedia.Domain;

//public class LineItem
//{
//}

//public class LineItemSorter
//{
//}

//public class Foo
//{
//    public Bar Bar { get; set; }
//}

//public class Bar
//{
//}

//public class Order
//{
//    private readonly Foo _foo;
//    private readonly LineItemSorter _sorter;

//    public Order(
//        int customerId,
//        string description,
//        LineItemSorter sorter
//    )
//    {
//        CustomerId = customerId;
//        Description = description;
//        _sorter = sorter;
//        _foo = MakeFoo();
//    }

//    public int Id { get; }
//    public int CustomerId { get; }
//    public string Description { get; }
//    public IReadOnlyList<LineItem> LineItem { get; }

//    private Foo MakeFoo() =>
//        new()
//        {
//            Bar = new Bar()
//        };
//}

//public class WhenCreatingOrder
//{
//    #region Requirements

//    [Fact]
//    public void ThenCustomerIdIsSet()
//    {
//        var order = new Order(100, "a description", null);

//        order.CustomerId.Should().BeGreaterThan(0);
//    }

//    [Fact]
//    public void ThenDescriptionIsSet()
//    {
//        var order = new TestOrderFactory().Create();

//        order.Description.Should().NotBeNullOrWhiteSpace();
//    }

//    #endregion
//}

//public class TestOrderFactory
//{
//    private int _customerId = 100;
//    private string _description = "a description";
//    private LineItemSorter _sorter = new();

//    public Order Create() => new(_customerId, _description, _sorter);

//    public TestOrderFactory With(int customerId)
//    {
//        _customerId = customerId;
//        return this;
//    }

//    public TestOrderFactory With(string description)
//    {
//        _description = description;
//        return this;
//    }

//    public TestOrderFactory With(LineItemSorter sorter)
//    {
//        _sorter = sorter;
//        return this;
//    }
//}

//public class TestOrderFactory2
//{
//    private OrderComponents _orderComponents = OrderComponents.Default;

//    public Order Create()
//    {
//        var (customerId, description, sorter) = _orderComponents;
//        var order = new Order(customerId, description, sorter);
//        Reset();
//        return order;
//    }

//    public TestOrderFactory2 With(int customerId)
//    {
//        _orderComponents = _orderComponents with { CustomerId = customerId };
//        return this;
//    }

//    public TestOrderFactory2 With(string description)
//    {
//        _orderComponents = _orderComponents with { Description = description };
//        return this;
//    }

//    public TestOrderFactory2 With(LineItemSorter sorter)
//    {
//        _orderComponents = _orderComponents with { Sorter = sorter };
//        return this;
//    }

//    private void Reset() => _orderComponents = OrderComponents.Default;

//    private record OrderComponents(int CustomerId, string Description, LineItemSorter Sorter)
//    {
//        public static readonly OrderComponents Default = new(100, "a description", new LineItemSorter());
//    }
//}

//public static class ObjectProvider
//{
//    public static Order CreateOrder(int customerId, string description, LineItemSorter sorter) =>
//        new(customerId, description, sorter);
//}

//public interface ITokenGapParser
//{
//    string GetGapFulfillment(string foo, string bar, string bat);
//}

//public class TokenGapParserSpec
//{
//    private void SetupMocks()
//    {
//        _precodes = new List<PrecodeModel>
//        {
//            new PrecodeModel
//            {
//                PrecodeNumber = l,
//                PrecodeFieldExpression = PRECODE1_VALUE
//            },
//            new PrecodeModel
//            {
//                PrecodeNumber = 2,
//                PrecodeFieldExpression = PRECODE2_VALUE
//            },
//            new PrecodeModel
//            {
//                PrecodeNumber = 12,
//                PrecodeFieldExpression = PRECODE12_VALUE
//            }
//        };

//        SetupTextSizeCalculator();

//        _tokenLocationParserResolver = new Mock<ITokenLocationParserResolver>();
//        _tokenLocationParserResolver.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<Text>(), It.IsAny<Text>(), It.IsAny<double>())).Returns(_tokenLocationParser.Object);

//        _tokenLocationParser = new Mock<ITokenLocationParser>();
//        _tokenLocationParser.Setup(x => x.GetTokenLocation()).Returns(new Location(BASE_TEXT_WIDTH, BASE_TEXT_HEIGHT));

//        _tokenGapParserResolver = new Mock<ITokenGapParserResolver>();
//        _tokenGapParserResolver.Setup(x => x.Create(It.IsAny<string>())).Returns(_tokenGapParser.Object);

//        _tokenGapParser = new Mock<ITokenGapParser>();
//        _tokenGapParser.Setup(x => x.GetGapFulfillment(It.IsAny<string>(), It.IsAny<string>(), Fonts.TraditionalQuestionText)).Returns(TOKEN_REPLACEMENT);

//        _tokenPreviewTextDisplay = new Mock<ITokenPreviewTextDisplay>();
//        _tokenPreviewTextDisplay.Setup(
//            x =>
//            x.GetPreviewTextToDisplay(It.Is<string>(t => t.Contains(GREETING_PREVIEW_WITH_NO_TOKEN)),
//            It.IsAny<Font>())).Returns((Text)null);
//        _tokenPreviewTextDisplay.Setup(
//            x =>
//            x.GetPreviewTextToDisplay(It.Is<string>(t => t.Contains(GREETING_PREVIEW_WITH_TOKEN)),
//            It.IsAny<Font>())).Returns(new Text(GREETING_PREVIEM_MITH_TOKEM_RESULT, Fonts.TraditionalQuastionText));
//        _tokenPreviewTextDisplay.Setup(
//            x =>
//            x.GetPreviewTextToDisplay(It.Is<string>(t => t.Contains(PRECODE1_FORMATED_VALUE)),
//            It.IsAny<Font>())).Returns(new Text(PRECODE1_FORMATED_VALUE, Fonts.TraditionalQuestionText));
//        _tokenPreviewTextDisplay.Setup(
//            x =>
//            x.GetPreviewTextToDisplay(It.Is<string>(t => t.Contains(PRECODE1_KEY)), It.IsAny<Font>()))
//            .Returns(new Text(PRECODE1_VALUE_WITH_TOKEN, Fonts.TraditionalQuestionText));
//        _tokenPreviewTextDisplay.Setup(
//            x =>
//            x.GetPreviewTextToDisplay(It.Is<string>(t => t.Contains(PRECODE12_FORMATED_VALUE)), It.IsAny<Font>()))
//            .Returns(new Text(PRECODE12_FORMATED_VALUE, Fonts.TraditionalQuestionText));
//        _tokenPreviewTextDisplay.Setup(
//            x =>
//            x.GetPreviewTextToDisplay(It.Is<string>(t => t.Contains(PRECODE12_KEY)), It.IsAny<Font>()))
//            .Returns(new Text(PRECODE12_VALVE_WITH_TOKEN, Fonts.TraditionalQuestionText));
//        _tokenPreviewTextDisplay.Setup(
//            x =>
//            x.GetPreviewTextToDisplay(It.Is<string>(t => t.Contains(PRECODE_4_KEY)), It.IsAny<Font>()))
//            .Returns(new Text(PRECODE4_VALUE_WITH_TOKEN, Fonts.TraditionalQuestionText));
//        _tokenPreviewTextDisplay.Setup(
//            x =>
//            x.GetPreviewTextToDisplay(It.Is<string>(t => t.Equals(TOKEN_KEY)), It.IsAny<Font>()))
//            .Returns(new Text(TOKEN_KEY, Fonts.TraditionalQuestionText));

//        _tokenPreviewTextDisplayResolver = new Mock<ITokenPreviewTextDisplayResolver>();
//        _tokenPreviewTextDisplayResolver.Setup(x => x.Create(PRECODE1_KEY)).Returns(_tokenPreviewTextDisplay.Object);
//        _tokenPreviewTextDisplayResolver.Setup(x => x.Create(PRECODE_4_KEY)).Returns(_tokenPreviewTextDisplay.Object);
//        _tokenPreviewTextDisplayResolver.Setup(x => x.Create(GREETING_KEY)).Returns(_tokenPreviewTextDisplay.Object);
//        _tokenPreviewTextDisplayResolver.Setup(x => x.Create(TOKEN_KEY)).Returns(_tokenPreviewTextDisplay.Object);
//        _tokenPreviewTextDisplayResolver.Setup(x => x.Create(PRECODE12_KEY)).Returns(_tokenPreviewTextDisplay.Object);

//        _dynamicQuestionSampleProvider = new Mock<IDynamicQuestionSampleProvider>();
//        _dynamicQuestionSampleProvider.Setup(x => x.Map());

//        _yesNoInstructionsMessageBoxFactory = new Mock<IYesNoInstructionsMessageBoxFactory>();
//        _yesNoInstructionsHessageBoxFactory.Setup(x => x.Create(It.IsAny<HtmlTextModel>(), It.IsAny<HtmlTextModel>(), It.IsAny<double>())).Returns(new YesNoInstructionsMessageBox(
//            new HtmlTextModel("yes"), new Circle(0.1), new HtmlTextModel("no"), new Circle(0.1), 7));

//        _precodePrintVariableCommandTypeEnumResolver = new Mock<IPrintVariableCommandTypeResolver>();
//        _precodePrintVariableCommandTypeEnumResolver.Setup(x => x.ResolveByTokenName(PRECODE1_KEY))
//        .Returns(PrintVariableCommandType.Precode1);
//        _precodePrintVariableCommandTypeEnumResolver.Setup(x => x.ResolveByTokenName(PRECODE12_KEY))
//        .Returns(PrintVariableCommandType.Precode12);

//        SetupCoverLetter();
//        _coverletterProvider new Mock<ICoverLetterProvider>();
//        _coverletterProvider.Setup(_ => _.CoverLetterModel).Returns(_coverletterModel);
//    }

//    private void SetupTextSizeCalculator()
//    {
//        _textSizeCalculator = new Mock<ITextSizeCalculator>();

//        _textSizeCalculator.Setup(x => x.CalculateSize(It.Is<Text>(t =>
//        t.Content == BASE_TEXT || t.Content == ANY_TEXT_WITH_SUPERSCRIPT)))
//        .Returns(new Size(BASE_TEXT_WIDTH, BASE_TEXT_HEIGHT));

//        _textSizeCalculator.Setup(
//            x => x.CalculateEndofTextBaselineLocation(It.Is<Text>(t => t.Content == BASE_TEXT)))
//            .Returns(new Location(BASE_TEXT_WIDTH, BASE_TEXT_HEIGHT));

//        _textSizeCalculator.Setup(x => x.CalculateLastLineBottomRightLocation(It.Is<Text>(t => t.Content == BASE_TEXT)))
//        .Returns(new Location(BASE_TEXT_WIDTH, BASE_TEXT_HEIGHT));

//        _textSizeCalculator.Setup(x =>
//        x.CalculateSize(
//            It.Is<Text>(text => text.Content == ONE_SPACE + Constants.ZERO_WIDTH_SPACE)))
//            .Returns(new Size(ONE_SPACE_WIDTH, 0d));

//        _textSizeCalculator.Setup(
//            x =>
//            x.CalculateSize(
//                It.Is<Text>(text => text.Content == BASE_TEXT + TOKEN_REPLACEMENT + Constants.ZERO_WIDTH_SPACE)))
//                .Returns(new Size(BASE_TEXT_WIDTH, BASE_TEXT_HEIGHT));

//        _textSizeCalculator.Setup(
//            x => x.CalculateEndOfTextBaselineLocation(
//                It.Is<Text>(text => text.Content == BASE_TEXT + TOKEN_REPLACEMENT + Constants.ZERO_WIDTH_SPACE))).
//                Returns(new Location(ANY_TEXT_WITH_ONE_PRECODE_WIDTH, ANY_TEXT_WITH_ONE_PRECODE_HEIGHT));

//        _textSizeCalculator.Setup(
//            x =>
//            x.CalculateLastLineBottomRightLocation(t => t.Content == BASE_TEXT + TOKEN_REPLACEMENT + Constants.ZERO_WIDTH_SPACE)))
//            .Returns(new Location(ANY_TEXT_WITH_ONE_PRECODE_WIDTH, ANY_TEXT_WITH_ONE_PRECODE_HEIGHT));

//        _textSizeCalculator.Setup(
//            x => x.CalculateSize(It.Is<Text>(text => text.Content.Contains("Recientemente Le mandamos una encuesta"))))
//            .Returns(new Size(ANY_TEXT_WITH_ONE_PRECODE_WIDTH, ANY_TEXT_WITH_ONE_PRECODE_HEIGHT));

//        _textSizeCalculator.Setup(
//        x =>
//        x.CalculateEndOfTextBaseLineLocation(
//        It.Is<Text>(text => text.Content.Contains("Recientemente le mandamos una encuesta")), It.IsAny<int>()))
//        .Returns(new Location(ANY_TEXT_WITH_ONE_PRECODE_WIDTH, ANY_TEXT_WITH_ONE_PRECODE_HEIGHT));

//        _textSizeCalculator.Setup(x => x.CalculateSize(
//            It.Is<Text>(
//                t =>
//                t.Content ==
//                BASE_TEXT + TOKEN_REPLACEMENT + SPACES + Constants.ZERO_WIDTH_SPACE + BASE_COMPLEMENT_TEXT)))
//                .Returns(new Size(BASE_TEXT_WIDTH, BASE_TEXT_HEIGHT));

//        IoC.Configure(x => x.Resolve<ITextSizeCalculator>().With(_textSizeCalculator.Object));
//    }

//    private void SetupCoverLetter()
//    {
//        _coverletterModel = new CoverLetterModel
//        {
//            ClientLogol = new LogoModel
//            {
//                FileID = 20289,
//                Extension = "jpg",
//                HorizontalAlignment = HorizontalAlignmentEnum.Center
//            },
//            ClientLogo2 = new LogoModel
//            {
//                FileID I 13186,
//                Extension = "png"
//            },
//            Signaturel = new SignatureModel
//            {
//                FileID = 12346,
//                Extension = "png",
//                NameTitle = new TextModel("Name 1\nTitle 1")
//            },
//            Signature2 = new SignatureModel
//            {
//                FileID = 12347,
//                Extension = "png",
//                NameTitle = new TextModel("Name 2\nTitle 2")
//            },
//            Signature3 = new SignatureModel
//            {
//                FileID = 12348,
//                Extension = "png",
//                NameTitle = new TextModel("Name 3\nTitle 2")
//            },
//            FooterText new HtmlTextModel("Cover letter footer"),
//            BodyText new HtmlTextModel("<div style=\"text-align:Left;font-style:normal;font-weight:normal;\"><p><span>RE: Your hospital discharge on {PRECODE4}</span></p><p><span></span></p><p><span>{GREETING} Our goal at HOSPITAL TEST is to provide our patients with the highest quality healthcare. One of the best ways to do this is to ask our patients what we are doing right and what may need improvement. The enclosed survey asks about the care you received during your hospital stay that ended on the date listed above. By sharing your thoughts and feelings, you can help us improve the care we provide. Please take a few minutes to complete the survey and return it in the postage-paid envelope.</span></p><p><span></span></p><p><span style=\"text-align:Left;font-style:normal;font-weight:bold;font-size:14\">Questions 1-25 are national initiative sponsored by the United States Department of Health and Human Services to measure the quality of care in hospitals. The overall results will provide comparisons on issues of hospital care that are important to all consumers.</span></p><p><span></span></p><p><span>Your answers may be shared with the hospital for quality improvement and may be used for research purposes. The number on the bottom of the survey is used to tell us if you returned the survey so we don't send you reminders.</span></p><p><span></span></p><p><span>Thank you in advance for completing this survey. Your participation is voluntary and will not affect your health benefits. If you have any questions about this survey please call xxx-xxx-xxxx. For other questions about your hospital stay, please call xxx-xxx-xxxx.</span></p><p><span></span></p><p><span>Sincerely.</span></p></div>"),
//            LanguageChangeText = new HtmlTextModel("Cover Letter Language Change Text"),
//            IncludeEnclosure = true,
//            EnclosureText new TextModel("Enclosure"),
//            Greeting = new TextModel(GREETING_PREVIEW_WITH_NO_TOKEN),
//            GreetingResourceId = 1
//        };

//        _coverletterModelGreetingWithToken = new CoverLetterModel
//        {
//            ClientLogol new LogoModel
//            {
//                FileID = 20289,
//                Extension = "jpg",
//                HorizontalALignment = HorizontalAlignmentEnum.Center
//            },
//            ClientLogo2 new LogoModel
//            {
//                FileID = 13186,
//                Extension = "png"
//            },
//            Signaturel = new SignatureModel
//            {
//                FileID = 12346,
//                Extension "png",
//                NameTitle = new TextModel("Name 1\nTitle 1")
//            },
//            Signature2 = new SignatureModel
//            {
//                FileID 12347,
//                Extension = "png",
//                NameTitle = new TextModel("Name 2\nTitle 2")
//            }
//            Signature3 new Signaturerodel
//            {
//                FileID = 12348,
//                 Extension = "png",
//                 NameTitle = new TextModel("Name 3\nTitle 2")
//            },
//            FooterText new HtmlTextModel ("Cover letter footer"),
//            BodyText new HtmlTextModel("<div style=\"text-align:Left;font-style:normal;font-weight:normal;\"><p><span>RE: Your hospital discharge on {PRECODE4}</span></p><p><span></span></p><p><span>{GREETING} Our goal at HOSPITAL TEST is to provide our patients with the highest quality healthcare. One of the best ways to do this is to ask our patients what we are doing right and what may need improvement. The enclosed survey asks about the care you received during your hospital stay that ended on the date listed above. By sharing your thoughts and feelings, you can help us improve the care we provide. Please take a few minutes to complete the survey and return it in the postage-paid envelope.</span></p><p><span></span></p><p><span style=\"text-align:Left;font-style:normal;font-weight:bold;font-size:14\">Questions 1-25 are national initiative sponsored by the United States Department of Health and Human Services to measure the quality of care in hospitals. The overall results will provide comparisons on issues of hospital care that are important to all consumers.</span></p><p><span></span></p><p><span>Your answers may be shared with the hospital for quality improvement and may be used for research purposes. The number on the bottom of the survey is used to tell us if you returned the survey so we don't send you reminders.</span></p><p><span></span></p><p><span>Thank you in advance for completing this survey. Your participation is voluntary and will not affect your health benefits. If you have any questions about this survey please call xxx-xxx-xxxx. For other questions about your hospital stay, please call xxx-xxx-xxxx.</span></p><p><span></span></p><p><span>Sincerely.</span></p></div>"),
//            LanguageChangeText = new HtmlTextModel("Cover Letter Language Change Text"),
//            IncludeEnclosure true,
//            EnclosureText = new TextModel("Enclosure"),
//            Greeting = new TextModel(GREETING_PREVIEW_WITH_TOKEN),
//            GreetingResourceId = 1
//        };

//        _coverletterModelGreetingNone = new CoverLetterModel
//        {
//            ClientLogo1 = new LogoModel
//            {
//                FileID = 20289,
//                Extension = "jpg",
//                HorizontalAlignment = HorizontalAlignmentEnum.Center
//            },
//            ClientLogo2 new LogoModel
//            {
//                FileID = 13186,
//                Extension = "png"
//            },
//            Signaturel = new SignatureModel
//            {
//                FileID = 12346,
//                Extension = "png",
//                NameTitle = new TextModel("Name l\nTitle 1")
//            },
//            Signature2 = new SignatureModel
//            {
//                FileID = 12347,
//                Extension = "png",
//                NameTitle = new TextHodel("Name 2\nTitle 2")
//            },
//            Signature3 = new SignatureModel
//            {
//                FileID = 12348,
//                Extension = "png",
//                NameTitle = new TextModel("Name 3\nTitle 2")
//            },
//            FooterText = new HtmlTextModel("Cover letter footer"),
//            BodyText = new HtmlTextModel("<div style=\"text-align:Left;font-style:normal;font-weight:normal;\"><p><span>RE: Your hospital discharge on {PRECODE4}</span></p><p><span></span></p><p><span>{GREETING} Our goal at HOSPITAL TEST is to provide our patients with the highest quality healthcare. One of the best ways to do this is to ask our patients what we are doing right and what may need improvement. The enclosed survey asks about the care you received during your hospital stay that ended on the date listed above. By sharing your thoughts and feelings, you can help us improve the care we provide. Please take a few minutes to complete the survey and return it in the postage-paid envelope.</span></p><p><span></span></p><p><span style=\"text-align:Left;font-style:normal;font-weight:bold;font-size:14\">Questions 1-25 are national initiative sponsored by the United States Department of Health and Human Services to measure the quality of care in hospitals. The overall results will provide comparisons on issues of hospital care that are important to all consumers.</span></p><p><span></span></p><p><span>Your answers may be shared with the hospital for quality improvement and may be used for research purposes. The number on the bottom of the survey is used to tell us if you returned the survey so we don't send you reminders.</span></p><p><span></span></p><p><span>Thank you in advance for completing this survey. Your participation is voluntary and will not affect your health benefits. If you have any questions about this survey please call xxx-xxx-xxxx. For other questions about your hospital stay, please call xxx-xxx-xxxx.</span></p><p><span></span></p><p><span>Sincerely.</span></p></div>"),
//            LanguageChangeText = new HtmlTextModel("Cover Letter Language Change Text"),
//            IncludeEnclosure = true,
//            EnclosureText = new TextModel("Enclosure"),
//            Greeting = null,
//            GreetingResourceId = l
//        }}
//    }

//    #region Requirements
//    public void SetupGapParser(string token)
//    {
//        _tokenGapParser.Setup(x =>
//                x.GetGapFulfillment(
//                    It.IsAny<string>(),
//                    It.IsAny<string>(),
//                    Fonts.TraditionalQuestionText))
//            .Returns(token);
//    }

//    [Theory]
//    [InlineData("{PIN}")]
//    [InlineData("{GREETING}")]
//    [InlineData("{PRECODE4}")]
//    [InlineData("{PRECODE12}")]
//    public void WhenGettingGap_Whatever(string token)
//    {
//        SetupGapParser(token);
//        whatever.Should().Be(expected);
//    }

//    [Fact]
//    public void DoSomething()
//    {
//        var tokenGapParser = new Mock<ITokenGapParser>()
//            .Setup(
//                x => x.GetGapFulfillment(
//                    It.IsAny<string>(),
//                    It.IsAny<string>(),
//                    Fonts.TraditionalQuestionText
//                )
//            )
//            .Returns("??");

//        _tokenPreviewTextDisplay
//            .Setup(
//                x =>
//                    x.GetPreviewTextToDisplay(
//                        It.Is<string>(t => t.Contains(PRECODE12_KEY)),
//                        It.IsAny<Font>()
//                    )
//            )
//            .Returns(new Text(PRECODE12_VALVE_WITH_TOKEN, Fonts.TraditionalQuestionText));

//        _tokenPreviewTextDisplay
//            .Setup(
//                x =>
//                    x.GetPreviewTextToDisplay(
//                        It.Is<string>(t => t.Contains(PRECODE_4_KEY)),
//                        It.IsAny<Font>()
//                    )
//            )
//            .Returns(new Text(PRECODE4_VALUE_WITH_TOKEN, Fonts.TraditionalQuestionText));

//        _tokenPreviewTextDisplay
//            .Setup(
//                x =>
//                    x.GetPreviewTextToDisplay(
//                        It.Is<string>(t => t.Equals(TOKEN_KEY)),
//                        It.IsAny<Font>()
//                    )
//            )
//            .Returns(new Text(TOKEN_KEY, Fonts.TraditionalQuestionText));
//    }

//    #endregion
//}


