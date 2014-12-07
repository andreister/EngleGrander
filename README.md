EngleGrander in C#
============

The two step Engle-Grander cointegration test, to detect relationship between time series X(t) and Y(t). 

* Form a new time series `U(t) = X(t) - Y(t)` and fit linear regression `LM(t)` for it
* Run Augmented Dickey-Fuller test against the residuals of `LM(t)` to check if `U(t)` is a stationary time series 