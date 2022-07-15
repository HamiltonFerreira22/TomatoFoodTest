
namespace TomatoFoodTest.Model.ResponseSchema
{
    public  class OrdersSchema
    {
        public static JSchema OrdersJson()
        {
            JSchema schema = JSchema.Parse(@"{
    '$schema': 'http://json-schema.org/draft-07/schema',
    'type': 'object',
    'required': [
        'total_discount',
        'status',
        '_meals',
        '_id',
        'total_amount',
        '_restaurant',
        'subtotal',
        '_user',
        'created_at',
        '__v'
    ],
    'properties': {
        'total_discount': {
            'type': 'number'
        },
        'status': {
            'type': 'string'
        },
        '_meals': {
            'type': 'array',
            'items': {
                'type': 'string'
            }
        },
        '_id': {
            'type': 'string'
        },
        'total_amount': {
            'type': 'number'
        },
        '_restaurant': {
            'type': 'string'
        },
        'subtotal': {
            'type': 'number'
        },
        '_user': {
            'type': 'string'
        },
        'created_at': {
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
