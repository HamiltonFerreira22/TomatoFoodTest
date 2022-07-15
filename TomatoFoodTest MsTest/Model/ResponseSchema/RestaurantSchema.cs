
namespace TomatoFoodTest.Model.ResponseSchema
{
    public class RestaurantSchema
    {
        public static JSchema RestaurantJson()
        {
            JSchema schema = JSchema.Parse(@"{
    '$schema': 'http://json-schema.org/draft-07/schema',
    'type': 'object',
    'required': [
        '_meals',
        '_id',
        'name',
        'type',
        'description',
        '__v'
    ],
    'properties': {
        '_meals': {
            'type': 'array',
            'items': {
                'type': 'string'
            }
        },
        '_id': {
            'type': 'string'
        },
        'name': {
            'type': 'string'
        },
        'type': {
            'type': 'string'
        },
        'description': {
            'type': 'string'
        },
        '__v': {
            'type': 'integer'
        }
    }
}");
            return schema;
        }
    }
}
