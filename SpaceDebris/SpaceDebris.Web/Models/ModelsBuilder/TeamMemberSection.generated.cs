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
	/// <summary>Team member section</summary>
	[PublishedModel("teamMemberSection")]
	public partial class TeamMemberSection : PublishedElementModel, IHeaderTextsComp
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new const string ModelTypeAlias = "teamMemberSection";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<TeamMemberSection, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public TeamMemberSection(IPublishedElement content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Team member
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("teamMember")]
		public virtual global::System.Collections.Generic.IEnumerable<global::SpaceDebris.Web.Models.ModelsBuilder.TeamMember> TeamMember => this.Value<global::System.Collections.Generic.IEnumerable<global::SpaceDebris.Web.Models.ModelsBuilder.TeamMember>>("teamMember");

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
