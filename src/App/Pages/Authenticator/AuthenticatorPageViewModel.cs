﻿using System;
using System.Threading.Tasks;
using Bit.Core.Abstractions;
using Bit.Core.Utilities;

namespace Bit.App.Pages.Authenticator
{
    public class AuthenticatorPageViewModel : BaseViewModel
    {
        #region Members

        private readonly IClipboardService _clipboardService;
        private bool _showList;
        private bool _refreshing;
        private readonly IUserService _userService;
        private readonly IVaultTimeoutService _vaultTimeoutService;

        #endregion

        #region Ctor

        public AuthenticatorPageViewModel()
        {
            _userService = ServiceContainer.Resolve<IUserService>("userService");
            _vaultTimeoutService = ServiceContainer.Resolve<IVaultTimeoutService>("vaultTimeoutService");
        }

        #endregion

        #region Methods

        public async Task InitAsync() { }

        public async Task CopyAsync()
        {
            //await _clipboardService.CopyTextAsync(Password);
            //_platformUtilsService.ShowToast("success", null,
            //    string.Format(AppResources.ValueHasBeenCopied, AppResources.Password));
        }

        public async Task LoadAsync()
        {
            var authed = await _userService.IsAuthenticatedAsync();
            if (!authed)
            {
                return;
            }
            if (await _vaultTimeoutService.IsLockedAsync())
            {
                return;
            }

            this.ShowList = true;
            this.Refreshing = false;
        }

        #endregion

        #region Properties

        public bool ShowList
        {
            get => _showList;
            set => SetProperty(ref _showList, value);
        }

        public bool Refreshing
        {
            get => _refreshing;
            set => SetProperty(ref _refreshing, value);
        }

        #endregion
    }
}