# Health-Insurance is the test project with clean architect
سلام، این یکه پروژه نمونه با معماری تمیز برای نمایش نحوه پیاده سازی در پروژه های بزرگ و مقیاس پذیر هست
کارش محاسبه هزینه پوشش بیمه درمان براساس نوع پوشش و قیمت اون هست
و خب مشخصا برای نوشتن همچین برنامه ساده و نیاز به کوچکی سوار کردن همچین معماری سنگینی روی اون که فقط باعث افزودن پیچیدگی ها بهش میشه، نیست
اما چون من در اینجا میخواستم از این کد به عنوان پروژه نمونه و نمایش دستخط استفاده بکنم،
و نحوه پیاده سازی در پروژه های بزرگ رو نشون بدم تصمیم گرفتم از یک معماری مقیاس پذیر بهره بگیرم، تا بهتر بشه این موضوع رو نشون داد

# Seed data is:
SET IDENTITY_INSERT [dbo].[Coverages] ON
INSERT INTO [dbo].[Coverages] ([Id], [Title], [MinimumAmount], [MaximumAmount], [PremiumCoefficient]) VALUES (1, N'پوشش جراحی', CAST(5000.00 AS Decimal(18, 2)), CAST(50000000.00 AS Decimal(18, 2)), 0.0052)
INSERT INTO [dbo].[Coverages] ([Id], [Title], [MinimumAmount], [MaximumAmount], [PremiumCoefficient]) VALUES (2, N'پوشش دندانپزشکی', CAST(4000.00 AS Decimal(18, 2)), CAST(40000000.00 AS Decimal(18, 2)), 0.0042)
INSERT INTO [dbo].[Coverages] ([Id], [Title], [MinimumAmount], [MaximumAmount], [PremiumCoefficient]) VALUES (3, N'پوشش بستری', CAST(2000.00 AS Decimal(18, 2)), CAST(20000000.00 AS Decimal(18, 2)), 0.005)
SET IDENTITY_INSERT [dbo].[Coverages] OFF
توکن نامحدود دسترسی به کد: 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
