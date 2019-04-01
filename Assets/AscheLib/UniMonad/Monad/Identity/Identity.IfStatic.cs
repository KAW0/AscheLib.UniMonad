﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Identity {
		private class IfStaticCore<T> : IIdentityMonad<T> {
			IIdentityMonad<T> _thenSource;
			IIdentityMonad<T> _elseSource;
			Func<bool> _selector;
			public IfStaticCore(IIdentityMonad<T> thenSource, IIdentityMonad<T> elseSource, Func< bool> selector) {
				_thenSource = thenSource;
				_elseSource = elseSource;
				_selector = selector;
			}
			public T RunIdentity() {
				if(_selector()) {
					return _thenSource.RunIdentity();
				}
				else {
					return _elseSource.RunIdentity();
				}
			}
		}
		public static IIdentityMonad<T> If<T>(IIdentityMonad<T> thenSource, IIdentityMonad<T> elseSource, Func< bool> selector) {
			return new IfStaticCore<T>(thenSource, elseSource, selector);
		}
	}
}