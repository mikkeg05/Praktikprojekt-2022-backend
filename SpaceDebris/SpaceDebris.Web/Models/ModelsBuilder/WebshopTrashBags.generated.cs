//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v8.18.5
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace SpaceDebris.Web.Models.ModelsBuilder
{
	/// <summary>Webshop trash bags</summary>
	[PublishedModel("webshopTrashBags")]
	public partial class WebshopTrashBags : PublishedElementModel, IHeaderTextsComp
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new const string ModelTypeAlias = "webshopTrashBags";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<WebshopTrashBags, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public WebshopTrashBags(IPublishedElement content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Trash bag
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("trashBag")]
		public virtual global::System.Collections.Generic.IEnumerable<global::SpaceDebris.Web.Models.ModelsBuilder.TrashBagItem> TrashBag => this.Value<global::System.Collections.Generic.IEnumerable<global::SpaceDebris.Web.Models.ModelsBuilder.TrashBagItem>>("trashBag");

		///<summary>
		/// Header
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("header")]
		public virtual string Header => global::SpaceDebris.Web.Models.ModelsBuilder.HeaderTextsComp.GetHeader(this);

		///<summary>
		/// Sub header
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("subHeader")]
		public virtual string SubHeader => global::SpaceDebris.Web.Models.ModelsBuilder.HeaderTextsComp.GetSubHeader(this);
	}
}
