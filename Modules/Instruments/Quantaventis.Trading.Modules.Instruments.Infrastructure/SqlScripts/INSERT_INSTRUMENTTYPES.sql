SET IDENTITY_INSERT [instr].[InstrumentType] ON 
GO
INSERT [instr].[InstrumentType] ([InstrumentTypeId], [Mnemonic], [Description]) VALUES (1, N'EQU', N'Cash Equity')
GO
INSERT [instr].[InstrumentType] ([InstrumentTypeId], [Mnemonic], [Description]) VALUES (2, N'GENFUT', N'Generic Future Contract')
GO
INSERT [instr].[InstrumentType] ([InstrumentTypeId], [Mnemonic], [Description]) VALUES (3, N'FUT', N'Monthly Future Contract')
GO
INSERT [instr].[InstrumentType] ([InstrumentTypeId], [Mnemonic], [Description]) VALUES (4, N'CurrencyPair', N'CurrencyPair Currency Pair ')
GO
INSERT [instr].[InstrumentType] ([InstrumentTypeId], [Mnemonic], [Description]) VALUES (5, N'CurrencyPairFWD', N'FX Forward')
GO
SET IDENTITY_INSERT [instr].[InstrumentType] OFF