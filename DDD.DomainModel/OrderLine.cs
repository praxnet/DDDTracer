﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.DomainModel
{
    public class OrderLine
    {
        private ProductCatalog _product=null;
        private double _quantity=0;
        private Money _taxAmt = Money.Empty();
        public OrderLine(ProductCatalog product, double quantity)
        {
            this._product = product;
            this._quantity = quantity;
        }
        public double GetQuantity()
        {
            return this._quantity;
        }
        public ProductCatalog GetProduct()
        {
            return _product;
        }

        public Money GetCost()
        {
            return  new Money(_product.GetPrice().Value * this._quantity);
        }
        public Money GetSubTotal()
        {
            return this.GetCost() + _taxAmt;
        }
        internal void SetTaxAmount(Money taxAmt)
        {
            _taxAmt = taxAmt;
        }
        public Money GetTaxAmount()
        {
            return _taxAmt;
        }
        public bool IsTaxable()
        {
            return _product.IsTaxable();
        }
        public bool IsImported()
        {
            return _product.IsImported();
        }
    }
}