﻿using AlatTipMyself.Api.DTO;
using AlatTipMyself.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AlatTipMyself.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;


        public TransactionsController(ITransactionService transactionService, IMapper mapper, IUserService userService)
        {
            _transactionService = transactionService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("SendMoney")]
        [ProducesResponseType(typeof(WalletHistoryDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SendMoneyAsync(string FromAccount, [FromBody]SendMoneyParameter sendingDetails)
        {
            //if (sendingDetails == null) return BadRequest(new { StatusCode = 400, Message = "Fields cannot be empty" });
            var ToAccount = sendingDetails.ToAccount;
            var TransactionPin = sendingDetails.TransactionPin;
            var Amount = sendingDetails.Amount;
            var walletHistory = await _transactionService.SendMoneyAsync(FromAccount, ToAccount, Amount, TransactionPin);
            var walletHistoryDto = _mapper.Map<WalletHistoryDto>(walletHistory);
            await _userService.SaveAsync();
            return Ok(walletHistoryDto);
        }

        [HttpGet]
        [Route("TransactionHistory")]
        [ProducesResponseType(typeof(IEnumerable<TransactionsDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllTransactionsAsync(string AcctNumber)
        {
            var transactionHistories = await _transactionService.GetAllTransactionsAsync(AcctNumber);
            var mappedTransactionHistories = _mapper.Map<IEnumerable<TransactionsDto>>(transactionHistories);
            await _userService.SaveAsync();
            return Ok(mappedTransactionHistories);
        }

        [HttpGet]
        [Route("WalletHistory")]
        public async Task<IActionResult> GetAllWalletHistoriesAsync(string AcctNumber)
        {
            var walletHistories = await _transactionService.GetAllWalletHistoriesAsync(AcctNumber);
            var mappedWalletHistories = _mapper.Map<IEnumerable<WalletHistoryDto>>(walletHistories);
            await _userService.SaveAsync();
            return Ok(mappedWalletHistories);
        }
    }
}
