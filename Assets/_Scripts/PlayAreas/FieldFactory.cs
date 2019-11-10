using System.Collections.Generic;
using UnityEngine;
using _Scripts.Installers;

namespace _Scripts.PlayAreas
{
    public class FieldFactory : IFieldFactory
    {
        private readonly IViewFactory<FieldView> _fieldViewFactory;
        private readonly FieldController.Factory _fieldControllerFactory;

        public FieldFactory(IViewFactory<FieldView> fieldViewFactory, FieldController.Factory fieldControllerFactory)
        {
            _fieldViewFactory = fieldViewFactory;
            _fieldControllerFactory = fieldControllerFactory;
        }

        public Dictionary<int, Dictionary<int, IFieldView>> Create(Transform parent, Vector2Int size)
        {
            var fields = new Dictionary<int, Dictionary<int, IFieldView>>(size.x);
            for (var i = 0; i < size.x; i++)
            {
                fields.Add(i, new Dictionary<int, IFieldView>(size.y));

                for (var j = 0; j < size.y; j++)
                {
                    var position = new Vector3(i - size.x / 2.0f, 0, j);
                    var view = CreateFieldView(parent, position);

                    fields[i].Add(j, view);
                }
            }

            return fields;
        }

        private IFieldView CreateFieldView(Transform parent, Vector3 position)
        {
            var view = _fieldViewFactory.Instantiate(parent);
            view.Position = position;
            _fieldControllerFactory.Create(view);

            return view;
        }
    }
}