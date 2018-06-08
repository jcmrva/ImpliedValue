
## ImpliedDecimal

Allows you to hide that pesky separator in decimal values.

Why would anyone want this?

I found myself asking a similar question as I examined some code that interacts with a financial partner's electronic payments system. A bit of research suggests some legacy mainframe systems have difficulty representing decimal values, thus the "implied decimals" concept was created.

Why make a library for it?

If my efforts can assist even one poor soul in managing this archaic requirement, I will have done well.

Written as a struct to ensure value type semantics.

Design goals:
 - Value should not be lost (truncation) unless explicitly desired.
 - Include implicit decimal conversion because the underlying value is a decimal and, most likely, the input value as well.
 - NO implicit int or string conversion.
